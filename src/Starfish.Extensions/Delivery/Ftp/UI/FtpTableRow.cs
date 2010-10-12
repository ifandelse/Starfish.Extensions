using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpTableRow : HtmlTableRow
    {
        public FtpTableRow AddCell(FtpTableCell cell)
        {
            this.Cells.Add(cell);
            return this;
        }

        public static FtpTableRow Create()
        {
            return new FtpTableRow();
        }
    }
}
