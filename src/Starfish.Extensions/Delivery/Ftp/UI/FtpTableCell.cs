using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpTableCell : HtmlTableCell
    {
        public FtpTableCell AddControl(WebControl control)
        {
            this.Controls.Add(control);
            return this;
        }

        #region Fluent Config...

        public FtpTableCell SetWidth(string width)
        {
            this.Width = width;
            return this;
        }

        public FtpTableCell HorizontalAlign(string horizontalAlign)
        {
            this.Align = horizontalAlign;
            return this;
        }

        public FtpTableCell VerticalAlign(string verticalAlign)
        {
            this.VAlign = verticalAlign;
            return this;
        }

        public FtpTableCell CssClass(string cssClass)
        {
            this.Attributes.Add("class", cssClass);
            return this;
        }

        public FtpTableCell ColumnSpan(int colSpan)
        {
            this.ColSpan = colSpan;
            return this;
        }

        #endregion

        public static FtpTableCell Create()
        {
            return new FtpTableCell();
        }
    }
}
