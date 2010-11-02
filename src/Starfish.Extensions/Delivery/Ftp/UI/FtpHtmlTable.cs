using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Starfish.Extensions.Delivery.Ftp.UI
{
    public class FtpHtmlTable : HtmlTable
    {
        public TextBox FtpUri { get; set; }
        public TextBox FtpPort { get; set; }
        public TextBox FtpFolder { get; set; }
        public CheckBox EnableSsl { get; set; }
        public DropDownList FileFormat { get; set; }
        public CheckBox KeepAlive { get; set; }
        public TextBox Password { get; set; }
        public TextBox TargetFileName { get; set; }
        public CheckBox UseBinary { get; set; }
        public CheckBox UsePassive { get; set; }
        public TextBox UserName { get; set; }
        public DropDownList DateTimeFormatToAppend { get; set; }
        public CheckBox AppendExecutionDateToFileName { get; set; }

        private FtpHtmlTable()
        {
            InitControls();
            InitTable();
        }

        public FtpHtmlTable AddRow(FtpTableRow row)
        {
            this.Rows.Add(row);
            return this;
        }

        public static FtpHtmlTable Create()
        {
            return new FtpHtmlTable();
        }

        private void InitControls()
        {
            FtpUri = new TextBox() { CssClass = "msrs-txtBox" };
            FtpFolder = new TextBox() { CssClass = "msrs-txtBox" };
            FtpPort = new TextBox() { CssClass = "msrs-txtBox", Text = "21"};
            EnableSsl = new CheckBox();
            FileFormat = new DropDownList();
            KeepAlive = new CheckBox();
            Password = new TextBox() { CssClass = "msrs-txtBox" };
            TargetFileName = new TextBox() { CssClass = "msrs-txtBox" };
            UseBinary = new CheckBox();
            UsePassive = new CheckBox();
            UserName = new TextBox() { CssClass = "msrs-txtBox" };
            AppendExecutionDateToFileName = new CheckBox();
            DateTimeFormatToAppend = new DropDownList();
        }

        private void InitTable()
        {
            this.Attributes.Add("class", "msrs-normal");
            AddRow(FtpTableRow
                    .Create()
                    .AddCell(FtpTableCell
                                .Create()
                                .ColumnSpan(1)
                                .AddControl(FtpLabel
                                            .Create("lblFtpUri")
                                            .ElementText("FTP URI")))
                    .AddCell(FtpTableCell
                                .Create()
                                .ColumnSpan(3)
                                .AddControl(FtpUri)))
            .AddRow(FtpTableRow
                    .Create()
                    .AddCell(FtpTableCell
                                .Create()
                                .ColumnSpan(1)
                                .AddControl(FtpLabel
                                            .Create("lblFtpPort")
                                            .ElementText("FTP Port")))
                    .AddCell(FtpTableCell
                                .Create()
                                .ColumnSpan(3)
                                .AddControl(FtpPort)))
            .AddRow(FtpTableRow
                        .Create()
                        .AddCell(FtpTableCell
                                    .Create()
                                    .ColumnSpan(1)
                                    .AddControl(FtpLabel
                                                .Create("lblUserName")
                                                .ElementText("User Name")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .ColumnSpan(3)
                                    .AddControl(UserName)))
            .AddRow(FtpTableRow
                        .Create()
                        .AddCell(FtpTableCell
                                    .Create()
                                    .ColumnSpan(1)
                                    .AddControl(FtpLabel
                                                .Create("lblPassword")
                                                .ElementText("Password")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .ColumnSpan(3)
                                    .AddControl(Password)))
            .AddRow(FtpTableRow
                        .Create()
                        .AddCell(FtpTableCell
                                    .Create()
                                    .ColumnSpan(1)
                                    .AddControl(FtpLabel
                                                .Create("lblFtpFolder")
                                                .ElementText("Folder")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .ColumnSpan(3)
                                    .AddControl(FtpFolder)))
            .AddRow(FtpTableRow
                        .Create()
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(FtpLabel
                                                .Create("lblTargetFileName")
                                                .ElementText("Target File Name")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(TargetFileName))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(FtpLabel
                                                .Create("lblFileFormat")
                                                .ElementText("File Format")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(FileFormat)))
            .AddRow(FtpTableRow
                        .Create()
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(FtpLabel
                                                .Create("lblAppendDateTimeFormatToFileName")
                                                .ElementText("Append Date/Time to File")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(AppendExecutionDateToFileName))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(FtpLabel
                                                .Create("lblDateTimeFormatToAppend")
                                                .ElementText("Format To Append")))
                        .AddCell(FtpTableCell
                                    .Create()
                                    .AddControl(DateTimeFormatToAppend)))
            .AddRow(FtpTableRow
                    .Create()
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(FtpLabel
                                            .Create("lblEnableSsl")
                                            .ElementText("Enable SSL")))
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(EnableSsl))
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(FtpLabel
                                            .Create("lblKeepAlive")
                                            .ElementText("Keep Alive")))
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(KeepAlive)))
            .AddRow(FtpTableRow
                    .Create()
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(FtpLabel
                                            .Create("lblUseBinary")
                                            .ElementText("Use Binary")))
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(UseBinary))
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(FtpLabel
                                            .Create("lblUsePassive")
                                            .ElementText("Use Passive")))
                    .AddCell(FtpTableCell
                                .Create()
                                .AddControl(UsePassive)));
        }
    }
}
