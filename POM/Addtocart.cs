using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.POM
{
    public class AddToCart : BasePage
    {
        #region Locators
        By tablets = By.Id("tabletsImg");
        By quantity = By.ClassName("plus");
        By addToCartBtn = By.Name("save_to_cart");
        By validation = By.Id("checkOutPopUp");
        #endregion

        #region Method
        public void selectproduct()
        {
            // Navigate directly to a known tablet product (HP ElitePad 1000 G2)
            // Confirmed from home page popular items: product 16 is a tablet
            driver.Url = "https://advantageonlineshopping.com/#/product/16";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wait for the product page to load — save_to_cart button appears when ready
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("save_to_cart")));
            }
            catch (WebDriverTimeoutException)
            {
                // Try alternative product (product 10)
                driver.Url = "https://advantageonlineshopping.com/#/product/10";
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("save_to_cart")));
            }
        }

        public void select_category_color_AddToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            // Pick the first available color radio on the product page
            IWebElement? colorInput = null;
            try
            {
                colorInput = wait.Until(d =>
                {
                    var radios = d.FindElements(By.XPath("//input[@name='colorsList']"));
                    return radios.FirstOrDefault(r => r.Enabled) ?? (IWebElement?)null;
                });
            }
            catch (WebDriverTimeoutException) { /* product may have no color options */ }

            if (colorInput != null)
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", colorInput);

            Click(quantity);
            Click(addToCartBtn);
        }

        public void validate()
        {
            WaitForElementToBeVisible(validation);

            bool isCheckoutVisible = IsElementVisible(validation);

            if (isCheckoutVisible)
            {
                Console.WriteLine("Product has been successfully added to the cart.");
            }
            else
            {
                Console.WriteLine("Product was not added to the cart.");
            }
        }

        public void WaitForElementToBeVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public bool IsElementVisible(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void addToCart()
        {
            selectproduct();
            select_category_color_AddToCart();
            validate();
        }

        #endregion
    }
}
