using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace EcommerceWebsite
{
    public class BasePage
    {
        public static IWebDriver driver;

        public static void SeleniumInit(string browser)
        {
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--force-device-scale-factor=1.1");
                driver = new ChromeDriver(chromeOptions);
            }
        }

        private IWebElement WaitUntilElementIsClickable(By by, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        private IWebElement WaitUntilElementIsVisible(By by, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        private void WaitForLoaderToDisappear(int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver =>
            {
                var loader = driver.FindElement(By.ClassName("loader"));
                return !loader.Displayed;  
            });
        }

        public void Write(By by, string data)
        {
            WaitForLoaderToDisappear(); 
            IWebElement element = WaitUntilElementIsVisible(by);
            element.SendKeys(data);
        }

        public void Click(By by)
        {
            WaitForLoaderToDisappear();
            IWebElement element = WaitUntilElementIsClickable(by);
            element.Click();
        }

        public void SelectDropdownByText(By by, string text)
        {
            WaitForLoaderToDisappear(); 
            IWebElement dropdownElement = WaitUntilElementIsClickable(by); 
            SelectElement select = new SelectElement(dropdownElement); 
            select.SelectByText(text); 
        }


        public void OpenURL(string url)
        {
            driver.Url = url;
        }

        public void ClickUsingJavaScript(By by)
        {
            WaitForLoaderToDisappear();

            // Use JavaScript to click on the element
            IWebElement element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

    }
}
