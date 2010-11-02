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
            if(config == null)
            {
                throw new Exception("The FTP Configuration cannot be null.");
            }
            var builder = new UriBuilder(config.Uri);
            var targetFile = StripLeadingAndTrailingSlashes(config.TargetFileName);
            if (config.AppendExecutionDateToFileName)
            {
                int idx = targetFile.LastIndexOf(".");
                if (idx != -1)
                {
                    targetFile = String.Format("{0}{1}.{2}", targetFile.Substring(0, idx - 1), DateTime.Now.ToString(config.DateTimeFormatToAppend), targetFile.Substring(idx + 1));
                }
                else
                {
                    targetFile = String.Format("{0}{1}", targetFile, DateTime.Now.ToString(config.DateTimeFormatToAppend));
                }
            }
            if(!String.IsNullOrEmpty(config.FtpFolder))
            {
                var ftpFolder = StripLeadingAndTrailingSlashes(config.FtpFolder);
                builder.Path = String.Format("{0}/{1}", ftpFolder, targetFile);
            }
            else
            {
                builder.Path = targetFile;
            }
            _ftpWebRequest = WebRequest.Create(builder.Uri) as FtpWebRequest;
            if(_ftpWebRequest == null)
            {
                throw new Exception("There was a problem creating the FtpWebRequest.");
            }
            _ftpWebRequest.Credentials = new NetworkCredential(config.UserName, config.Password);
            _ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            _ftpWebRequest.KeepAlive = config.KeepAlive;
            _ftpWebRequest.EnableSsl = config.EnableSsl;
            _ftpWebRequest.UseBinary = config.UseBinary;
            _ftpWebRequest.UsePassive = config.UsePassive;
        }

        private string StripLeadingAndTrailingSlashes(string path)
        {
            var newPath = path.EndsWith("/")
                            ? path.Substring(0, path.Length - 2)
                            : path;
            newPath = newPath.StartsWith("/")
                        ? newPath.Substring(1)
                        : newPath;
            return newPath;
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
