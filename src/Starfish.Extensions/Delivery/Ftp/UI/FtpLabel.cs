using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpLabel : Label
    {
        private string _controlName;

        private FtpLabel(string controlName)
        {
            _controlName = controlName;
        }

        public static FtpLabel Create(string controlName)
        {
            return new FtpLabel(controlName);
        }

        #region Fluent Config...

        public static FtpLabel New(string controlName)
        {
            return new FtpLabel(controlName);
        }

        public FtpLabel ElementText(string text)
        {
            this.Text = text;
            return this;
        }

        public FtpLabel ElementId(string text)
        {
            this.ID = text;
            return this;
        }

        public FtpLabel ElementClass(string cssClass)
        {
            this.CssClass = cssClass;
            return this;
        }

        public FtpLabel ElementWidth(string width)
        {
            this.Style.Add("width", width);
            return this;
        }

        #endregion
    }
}
