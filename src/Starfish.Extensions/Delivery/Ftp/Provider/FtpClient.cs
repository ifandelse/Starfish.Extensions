using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;

namespace Starfish.Extensions.Delivery.Ftp.Provider
{
    public class FtpClient
    {
        private FtpWebRequest _ftpWebRequest;

        protected FtpClient(FtpClientConfiguration config)
        {
            string fullUri = Path.Combine(config.Uri, config.TargetFileName);
            UriBuilder builder = new UriBuilder(config.Uri);
            builder.Path = config.TargetFileName;
            _ftpWebRequest = FtpWebRequest.Create(builder.Uri) as FtpWebRequest;
            _ftpWebRequest.Credentials = new NetworkCredential(config.UserName, config.Password);
            _ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            _ftpWebRequest.KeepAlive = config.KeepAlive;
            _ftpWebRequest.EnableSsl = config.EnableSsl;
            _ftpWebRequest.UseBinary = config.UseBinary;
            _ftpWebRequest.UsePassive = config.UsePassive;
        }

        public void UploadFile(byte[] bytes)
        {
            using (var strm = _ftpWebRequest.GetRequestStream())
            {
                strm.Write(bytes, 0, bytes.Length);
                strm.Close();
            }
        }

        public static FtpClient GetClientFromSettings(FtpClientConfiguration ftpClientConfiguration)
        {
            return new FtpClient(ftpClientConfiguration);
        }
    }
}
