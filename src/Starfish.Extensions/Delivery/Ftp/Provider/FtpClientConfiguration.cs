using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ReportingServices.Interfaces;

namespace Starfish.Extensions.Delivery.Ftp.Provider
{
    public class FtpClientConfiguration
    {
        public bool EnableSsl { get; set; }
        public string FileFormat { get; set; }
        public int FtpPort { get; set; }
        public string FtpFolder { get; set; }
        public bool KeepAlive { get; set; }
        public string Password { get; set; }
        public string TargetFileName { get; set; }
        public string Uri { get; set; }
        public bool UseBinary { get; set; }
        public bool UsePassive { get; set; }
        public string UserName { get; set; }
        public bool AppendExecutionDateToFileName { get; set; }
        public string DateTimeFormatToAppend { get; set; }

        public static FtpClientConfiguration GetFtpConfigurationFromSettings(Setting[] settings)
        {
            var settingsList = settings.ToList();
            var settingNames = settingsList.ToList().Select(s => s.Name);
            if (!settingNames.Contains("Password"))
            {
                throw new Exception("Password is a required setting.");
            }

            if (!settingNames.Contains("UserName"))
            {
                throw new Exception("UserName is a required setting.");
            }

            if (!settingNames.Contains("Uri"))
            {
                throw new Exception("Uri is a required setting.");
            }

            if (!settingNames.Contains("TargetFileName"))
            {
                throw new Exception("Target File Name is a required setting.");
            }

            if (!settingNames.Contains("FileFormat"))
            {
                throw new Exception("File Format is a required setting.");
            }

            var config = new FtpClientConfiguration();
            config.EnableSsl = settingNames.Contains("EnableSsl")
                                ? Convert.ToBoolean(settingsList.ToList().First(x => x.Name == "EnableSsl").Value)
                                : false;
            config.KeepAlive = settingNames.Contains("KeepAlive")
                                ? Convert.ToBoolean(settingsList.ToList().First(x => x.Name == "KeepAlive").Value)
                                : false;
            config.UseBinary = settingNames.Contains("UseBinary")
                                ? Convert.ToBoolean(settingsList.ToList().First(x => x.Name == "UseBinary").Value)
                                : true;
            config.UsePassive = settingNames.Contains("UsePassive")
                                ? Convert.ToBoolean(settingsList.ToList().First(x => x.Name == "UsePassive").Value)
                                : false;
            config.AppendExecutionDateToFileName = settingNames.Contains("AppendExecutionDateToFileName")
                                ? Convert.ToBoolean(settingsList.ToList().First(x => x.Name == "AppendExecutionDateToFileName").Value)
                                : false;
            config.FtpPort = settingNames.Contains("FtpPort")
                                ? Convert.ToInt32(settingsList.ToList().First(x => x.Name == "FtpPort").Value)
                                : 21;
            config.FtpFolder = settingNames.Contains("FtpFolder")
                                ? settingsList.ToList().First(x => x.Name == "FtpFolder").Value
                                : String.Empty;
            config.DateTimeFormatToAppend = settingNames.Contains("DateTimeFormatToAppend")
                                ? settingsList.ToList().First(x => x.Name == "DateTimeFormatToAppend").Value
                                : String.Empty;
            
            config.Password = settingsList.ToList().First(x => x.Name == "Password").Value;
            config.TargetFileName = settingsList.ToList().First(x => x.Name == "TargetFileName").Value;
            config.Uri = settingsList.ToList().First(x => x.Name == "Uri").Value;
            config.UserName = settingsList.ToList().First(x => x.Name == "UserName").Value;
            config.FileFormat = settingsList.ToList().First(x => x.Name == "FileFormat").Value;
            return config;
        }

        public Setting[] Settings
        {
            // TODO: Wire up a settings array
            get
            {
                List<Setting> settings = new List<Setting>()
                    {
                        new Setting()
                            {
                                DisplayName="FTP URL",
                                Name="FtpUrl",
                                ReadOnly = false,
                                Required = true,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="FTP Port",
                                Name="FtpPort",
                                ReadOnly = false,
                                Required = true,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="FTP Folder",
                                Name="FtpFolder",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Enable SSL",
                                Name="EnableSsl",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Keep Alive",
                                Name="KeepAlive",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Use Binary",
                                Name="UseBinary",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Use Passive",
                                Name="UsePassive",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Append Execution Date To File Name",
                                Name="AppendExecutionDateToFileName",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Date Time Format To Append",
                                Name="DateTimeFormatToAppend",
                                ReadOnly = false,
                                Required = false,
                                IsPassword = false,
                                Encrypted = false,
                                ValidValues = new ValidValue[]
                                                  {
                                                      new ValidValue() {Label = "yyyyMMdd", Value = "yyyyMMdd"},
                                                      new ValidValue() {Label = "MM-dd-yyyy", Value = "MM-dd-yyyy"},
                                                      new ValidValue() {Label = "yyyyMMddhhmmss", Value = "yyyyMMddhhmmss"}
                                                  }
                            },
                        new Setting()
                            {
                                DisplayName="Target File Name",
                                Name="TargetFileName",
                                ReadOnly = false,
                                Required = true,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="File Format",
                                Name="FileFormat",
                                ReadOnly = false,
                                Required = true,
                                IsPassword = false,
                                Encrypted = false,
                                ValidValues = new ValidValue[]
                                                  {
                                                      new ValidValue() {Label = "Excel", Value = "xls"},
                                                      new ValidValue() {Label = "PDF", Value = "pdf"},
                                                      new ValidValue() {Label = "CSV", Value = "csv"},
                                                      new ValidValue() {Label = "IMAGE", Value = "tiff"},
                                                      new ValidValue() {Label = "XML", Value = "xml"},
                                                      new ValidValue() {Label = "Word", Value = "doc"},
                                                      new ValidValue() {Label = "MHTML", Value = "mhtml"}
                                                  }
                            },
                        new Setting()
                            {
                                DisplayName="Username",
                                Name="UserName",
                                ReadOnly = false,
                                Required = true,
                                IsPassword = false,
                                Encrypted = false
                            },
                        new Setting()
                            {
                                DisplayName="Password",
                                Name="Password",
                                ReadOnly = false,
                                Required = true,
                                IsPassword = false,
                                Encrypted = true
                            }
                    };
                return settings.ToArray();
            }
        }

        public Setting[] ValidateSettings(Setting[] settings)
        {
            // TODO: Add some real validation here!
            return settings;
        }

        public Setting[] ToSettingsArray()
        {
            return new Setting[13]
            { 
                new Setting() { Name = "EnableSsl", Value = EnableSsl.ToString() },
                new Setting() { Name = "FileFormat", Value = FileFormat },
                new Setting() { Name = "FtpPort", Value = FtpPort.ToString() },
                new Setting() { Name = "FtpFolder", Value = FtpFolder },
                new Setting() { Name = "KeepAlive", Value = KeepAlive.ToString() },
                new Setting() { Name = "Password", Value = Password },
                new Setting() { Name = "TargetFileName", Value = TargetFileName },
                new Setting() { Name = "Uri", Value = Uri },
                new Setting() { Name = "UseBinary", Value = UseBinary.ToString() },
                new Setting() { Name = "UsePassive", Value = UsePassive.ToString() },
                new Setting() { Name = "UserName", Value = UserName },
                new Setting() { Name = "AppendExecutionDateToFileName", Value = AppendExecutionDateToFileName.ToString() },
                new Setting() { Name = "DateTimeFormatToAppend", Value = DateTimeFormatToAppend }
            };
        }
    }
}
