using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpTextBox : TextBox
    {
        public static FtpTextBox Create()
        {
            return new FtpTextBox();
        }

        #region Fluent Config...

        public FtpTextBox ElementWidth(int width)
        {
            this.Width = Unit.Pixel(width);
            return this;
        }

        public FtpTextBox ElementId(string text)
        {
            this.ID = text;
            return this;
        }

        public FtpTextBox ElementClass(string cssClass)
        {
            this.CssClass = cssClass;
            return this;
        }

        public FtpTextBox ElementWidth(string width)
        {
            this.Style.Add("width", width);
            return this;
        }

        #endregion
    }
}
