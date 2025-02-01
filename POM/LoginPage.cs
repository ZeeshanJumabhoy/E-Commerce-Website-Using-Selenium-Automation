using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EcommerceWebsite.POM
{
    public class LoginPage : BasePage
    {
        #region Locators
        private By usernameTXT = By.Name("username");
        private By passwordTXT = By.Name("password");
        private By loginBTN = By.Id("sign_in_btn");
        private By menuUser = By.Id("menuUser");
        #endregion

        #region Methods
        public void Login(string url, string user, string pass)
        {
            OpenURL(url);
            Click(menuUser);
            Write(usernameTXT, user);
            Write(passwordTXT, pass);
            Click(loginBTN);
            ValidateLogin(user); 
        }

        private void ValidateLogin(string user)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
            wait.Until(d => d.FindElement(By.Id("menuUserLink")).Displayed);
            try
            {
                IWebElement userNameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='hi-user containMiniTitle ng-binding']")));
                string userName = userNameElement.Text;
                Assert.AreEqual(user, userName, "Login was not successful; the expected user name is not displayed.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("The user's name was not found within the timeout period.");
            }
        }
        #endregion
    }
}
