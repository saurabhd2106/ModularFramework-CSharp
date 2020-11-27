using OpenQA.Selenium;

namespace Guru99Application.Pages
{
    public class Guru99LoginPage : BasePage
    {
        private IWebDriver driver;

        private IWebElement username => driver.FindElement(By.Name("uid"));

        private IWebElement password => driver.FindElement(By.Name("password"));

        private IWebElement loginButton => driver.FindElement(By.Name("btnLogin"));

        public Guru99LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void LoginToApplication(string sUsername, string sPassword){

            commonElement.SetText(username, sUsername);

            commonElement.SetText(password, sPassword);

            commonElement.ClickElement(loginButton);

        }
    }
}