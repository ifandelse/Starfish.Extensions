using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Machine.Specifications;
using Starfish.Extensions.Delivery.Ftp.Provider;
using Moq;
using It = Machine.Specifications.It;

namespace Starfish.Extensions.Test.Delivery.Fp.Provider
{
    public class when_testing_that_an_ftp_configuration_correctly_configures_an_ftp_client
    {
        static FtpClient _ftpClient;
        static FtpClientConfiguration _config;

        static Establish context = () =>
        {
            var configMock = new Mock<FtpClientConfiguration>();
            configMock.Setup(x => x.Password).Returns("Password");
            configMock.Setup(x => x.EnableSsl).Returns(true);
            configMock.Setup(x => x.FileFormat).Returns("EXCEL");
            configMock.Setup(x => x.FtpPort).Returns(21);
            configMock.Setup(x => x.KeepAlive).Returns(false);
            configMock.Setup(x => x.TargetFileName).Returns("FileName.xls");
            configMock.Setup(x => x.Uri).Returns("ftp://somehost");
            configMock.Setup(x => x.UseBinary).Returns(true);
            configMock.Setup(x => x.UsePassive).Returns(false);
            configMock.Setup(x => x.UserName).Returns("UserName");
            _config = configMock.Object;
        };

        static Because of = () =>
        {
            _ftpClient = FtpClient.GetClientFromSettings(_config);
        };

        static It should_have_a_password_equal_to_Password = () =>
        {
            var pwd = (NetworkCredential)_ftpClient
                        .GetType()
                        .InvokeMember("_ftpWebRequest.Credentials", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic, null, _ftpClient, null);

            pwd.Password.ShouldEqual("Password");
        };

        static It should_have_enable_ssl_set_to_true = () =>
        {
            var enableSsl = (bool)_ftpClient
                        .GetType()
                        .InvokeMember("_ftpWebRequest.EnableSsl", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic, null, _ftpClient, null);

            enableSsl.ShouldBeTrue();
        };
    }
}
