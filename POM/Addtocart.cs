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
        By productSelect = By.Id("17");
        By colorSelect = By.Id("rabbit");
        By quantity = By.ClassName("plus");
        By addToCartBtn = By.Name("save_to_cart");
        By validation = By.Id("checkOutPopUp");
        #endregion

        #region Method
        public void selectproduct()
        {
            Click(tablets);
            Click(productSelect);
        }

        public void select_category_color_AddToCart()
        {
            Click(colorSelect);
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
