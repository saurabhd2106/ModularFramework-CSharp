using Guru99Tests.Utils;
using NUnit.Framework;

namespace Guru99Tests.Tests
{
    public class LoginPageTests : BaseTests
    {

        string excelFileName;



        [Test]
        [TestCaseSource(typeof(TestDataFromExcel), "getDataFromExcel")]
        public void VerifyLogin(string sUsername, string sPassword)
        {
            
            loginPage.LoginToApplication(sUsername, sPassword);
            
            Assert.Fail();
        }

      
    }
}