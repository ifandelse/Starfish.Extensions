using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using Microsoft.ReportingServices.Interfaces;
using Starfish.Extensions.Delivery.Ftp.Provider;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpDeliveryExtensionUI : WebControl, ISubscriptionBaseUIUserControl, IExtension
    {
        private FtpHtmlTable _table;

        public FtpDeliveryExtensionUI()
        {
            base.Init += FtpDeliveryExtensionUI_Init;
            base.PreRender += FtpDeliveryExtensionUI_PreRender;
        }

        private void FtpDeliveryExtensionUI_PreRender(object sender, EventArgs e)
        {
            _table.FileFormat.DataSource = new List<string>(ReportServerInformation.RenderingExtension.Select(s => s.Name).Where(x => x != "NULL"));
            _table.FileFormat.DataBind();
        }

        private void FtpDeliveryExtensionUI_Init(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            _table = FtpHtmlTable.Create();
            Controls.Add(_table);
        }
        
        #region ISubscriptionBaseUIUserControl Members

        public string Description
        {
            get { return String.Format("Upload report to {0}.",_table.FtpUri.Text); }
        }

        public bool IsPrivilegedUser { get; set; }

        public IDeliveryReportServerInformation ReportServerInformation { get; set; }

        public Setting[] UserData
        {
            get
            {
                var config = new FtpClientConfiguration();
                config.EnableSsl = _table.EnableSsl.Checked;
                config.FileFormat = _table.FileFormat.SelectedValue;
                int port = 0;
                if (Int32.TryParse(_table.FtpPort.Text, out port))
                {
                    config.FtpPort = port;
                }
                else 
                {
                    config.FtpPort = 21; // Default port
                }
                config.KeepAlive = _table.KeepAlive.Checked;
                config.Password = _table.Password.Text;
                config.TargetFileName = _table.TargetFileName.Text;
                config.Uri = _table.FtpUri.Text;
                config.UseBinary = _table.UseBinary.Checked;
                config.UsePassive = _table.UsePassive.Checked;
                config.UserName = _table.UserName.Text;
                return config.ToSettingsArray();
            }
            set
            {
                var config = FtpClientConfiguration.GetFtpConfigurationFromSettings(value);
                _table.EnableSsl.Checked = config.EnableSsl;
                _table.FileFormat.SelectedValue = config.FileFormat;
                _table.FtpPort.Text = config.FtpPort.ToString();
                _table.KeepAlive.Checked = config.KeepAlive;
                _table.Password.Text = config.Password;
                _table.TargetFileName.Text = config.TargetFileName;
                _table.FtpUri.Text = config.Uri;
                _table.UseBinary.Checked = config.UseBinary;
                _table.UsePassive.Checked = config.UsePassive;
                _table.UserName.Text = config.UserName;
            }
        }

        public bool Validate()
        {
            // No additional validation is currently needed...
            return true;
        }

        #endregion

        #region IExtension Members

        public string LocalizedName
        {
            get { return "Starfish FTP Delivery Extension"; }
        }

        public void SetConfiguration(string configuration)
        {
            // currently no configuration to set.....
        }

        #endregion
    }
}
