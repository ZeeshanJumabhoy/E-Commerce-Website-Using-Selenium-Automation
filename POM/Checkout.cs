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
    public class Checkout : BasePage
    {

        #region Locators
        By checkOutBtn = By.Id("checkOutPopUp");
        By editShipping = By.ClassName("ng-scope");
        By firstName = By.Name("first_name");
        By lastName = By.Name("last_name");
        By phoneNum = By.Name("phone_number");
        By country = By.Name("countryListbox");
        By city = By.Name("city");
        By address = By.Name("address");
        By postalCode = By.Name("postal_code");
        By state = By.Name("state_/_province_/_region");
        By nextToPayBtn = By.Id("next_btn");
        By safePay = By.Name("safepay");
        By safePayUserName = By.Name("safepay_username");
        By safePayPassword = By.Name("safepay_password");
        By masterCredit = By.CssSelector("input[name='masterCredit'][ng-checked='checkedRadio == 2']");
        By masterCardNum = By.Name("card_number");
        By CVV = By.Name("cvv_number");
        By dateMonth = By.Name("mmListbox");
        By dateYear = By.Name("yyyyListbox");
        By cardHolderName = By.Name("cardholder_name");
        By payBtn = By.Id("pay_now_btn_SAFEPAY");
        By payBtn_mc = By.Id("pay_now_btn_ManualPayment");
        By validation = By.XPath("//h3[@translate='ORDER_PAYMENT']");
        #endregion

        #region Method
        public void editshippingdetails(string firstNameTXT, string lastNameTXT, string phoneTXT, string countryDrop,
                                        string cityTXT, string addressTXT, string postalTXT, string stateTXT)
        {
            Click(checkOutBtn);
            Click(nextToPayBtn);
        }

        public void paymentWithSafePay(string safePayUserNameTxt, string safePayPassTxt)
        {
            Write(safePayUserName, safePayUserNameTxt);
            Write(safePayPassword, safePayPassTxt);
            Thread.Sleep(10000);
            Click(payBtn);
        }

        public void paymentWithMasterCredit(string cardNumTXT, string cvvTXT, string monthDrop, string yearDrop, string cardHolderTxt)
        {
            ClickUsingJavaScript(masterCredit);
            Write(masterCardNum, cardNumTXT);
            Write(CVV, cvvTXT);
            SelectDropdownByText(dateMonth, monthDrop);
            SelectDropdownByText(dateYear, yearDrop);
            Write(cardHolderName, cardHolderTxt);
            Thread.Sleep(10000);
            Click(payBtn_mc);
        }

        public void vaidation()
        {
            try
            {
                string successCheckout = WaitUntilElementIsVisible(validation);
                if (successCheckout != "ORDER PAYMENT")
                {
                    throw new Exception("Unexpected validation message: " + successCheckout);
                }
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Checkout failed.");
            }
        }

        private string WaitUntilElementIsVisible(By element, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(element)).Text;
        }

        public void checkOutSafePay(string firstNameTXT, string lastNameTXT, string phoneTXT, string countryDrop,
                                             string cityTXT, string addressTXT, string postalTXT, string stateTXT,
                                             string paymentTypeTxt, string safePayUserNameTxt, string safePayPassTxt)
        {
            editshippingdetails(firstNameTXT, lastNameTXT, phoneTXT, countryDrop, cityTXT, addressTXT, postalTXT, stateTXT);
            if (paymentTypeTxt == "SafePay")
            {
                paymentWithSafePay(safePayUserNameTxt, safePayPassTxt);
                Thread.Sleep(1000);
            }
            vaidation();
        }

        public void checkOutMaster(string firstNameTXT, string lastNameTXT, string phoneTXT, string countryDrop,
                                     string cityTXT, string addressTXT, string postalTXT, string stateTXT, string paymentTypeTxt,
                                     string cardNumTXT, string cvvTXT, string monthDrop, string yearDrop, string cardHolderTxt)
        {
            editshippingdetails(firstNameTXT, lastNameTXT, phoneTXT, countryDrop, cityTXT, addressTXT, postalTXT, stateTXT);
            if (paymentTypeTxt == "Master")
            {
                paymentWithMasterCredit(cardNumTXT, cvvTXT, monthDrop, yearDrop, cardHolderTxt);
            }
            vaidation();
        }
        #endregion

    }
}
