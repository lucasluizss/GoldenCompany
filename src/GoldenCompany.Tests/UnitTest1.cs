using GoldenCompany.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldenCompany.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1() => Cryptography.SetKey(Guid.NewGuid().ToString());

        [TestMethod]
        public void TestMethod1()
        {
            var pwd = "Abcdefgh@12345";

            var pwdEncrypted = Cryptography.Encrypt(pwd);

            var pwdDecrypted = Cryptography.Decrypt(pwdEncrypted);

            Assert.AreEqual(pwd, pwdDecrypted);
        }
    }
}
