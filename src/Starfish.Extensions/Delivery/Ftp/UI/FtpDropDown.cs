using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpDropDown : DropDownList
    {
        public static FtpDropDown Create()
        {
            return new FtpDropDown();
        }
    }
}
