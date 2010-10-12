using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.ReportingServices.Interfaces;
using Starfish.Extensions.Delivery.Ftp.Provider;

namespace Starfish.Extensions.Delivery.Ftp.Provider
{
    public class FtpDeliveryExtension : IDeliveryExtension
    {
        private FtpClientConfiguration _settingsProvider;

        public FtpDeliveryExtension()
        {
            _settingsProvider = new FtpClientConfiguration();
        }

        #region IDeliveryExtension Members

        public bool Deliver(Notification notification)
        {
            bool success = false;
            try
            {
                notification.Retry = false;
                notification.Status = "Processing";

                var configuration = FtpClientConfiguration.GetFtpConfigurationFromSettings(notification.UserData);

                FtpClient ftpClient = FtpClient.GetClientFromSettings(configuration);
                RenderedOutputFile outputFile = notification.Report.Render(configuration.FileFormat, String.Empty)[0];
                outputFile.Data.Position = 0;
                using (var stream = outputFile.Data)
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    stream.Close();
                    ftpClient.UploadFile(bytes);
                }
                notification.Status = "Success";
                success = true;
            }
            catch (Exception ex)
            {
                notification.Status = String.Format("Error: {0}", ex.Message);
                success = false;
            }
            finally
            {
                notification.Save();
            }

            return success;
        }

        public Setting[] ExtensionSettings
        {
            get { return _settingsProvider.Settings; }
        }

        public bool IsPrivilegedUser { get; set; }

        public IDeliveryReportServerInformation ReportServerInformation { get; set; }

        public Setting[] ValidateUserData(Setting[] settings)
        {
            return _settingsProvider.ValidateSettings(settings);
        }

        #endregion

        #region IExtension Members

        public string LocalizedName
        {
            get { return "Starfish FTP Delivery Extension"; }
        }

        public void SetConfiguration(string configuration)
        {
           // TODO: Actually set configuration here (if it's even needed)....
        }

        #endregion
    }
}
