using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.POM
{
    public class MenuFunction : BasePage
    {
        #region locator
        private By menuUser = By.Id("menuUser"); 
        private By delete = By.ClassName("deleteBtnText");
        private By usernameTXT = By.Name("username");
        #endregion

        #region Method
        public void editaccount()
        {
            
        }

        public void deleteaccount() {
            Click(menuUser);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement signOutElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@translate='My_account']")));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", signOutElement);
            Thread.Sleep(1000);
            Click(delete);

        }

        public void signout()
        {
            // Click the menu to open the dropdown
            Click(menuUser);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement signOutElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@translate='Sign_out']")));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", signOutElement);
            Thread.Sleep(1000);
            Click(menuUser);

            // Optionally, validate if the user has been signed out
            validation("usernameFieldCheck");
        }



        public void validation(string type)
        {
            if (type == "usernameFieldCheck")
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementIsVisible(usernameTXT));

                    Console.WriteLine("Validation Passed: Username text field is displayed after sign-out.");
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail("Validation Failed: Username text field is not displayed after sign-out.");
                }
            }
            else
            {
                Console.WriteLine("Validation type not recognized.");
            }
        }


        #endregion

    }
}
