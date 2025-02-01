using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EcommerceWebsite.POM
{
    public class RegisterAccount : BasePage
    {
        #region Locators
        private By menuUser = By.Id("menuUser");
        private By Createaccountbutton = By.ClassName("create-new-account");
        private By usernameTXT = By.Name("usernameRegisterPage");
        private By emailTXT = By.Name("emailRegisterPage");
        private By passwordTXT = By.Name("passwordRegisterPage");
        private By confirmPasswordTXT = By.Name("confirm_passwordRegisterPage");
        private By firstNameTXT = By.Name("first_nameRegisterPage");
        private By lastNameTXT = By.Name("last_nameRegisterPage");
        private By phoneNumberTXT = By.Name("phone_numberRegisterPage");
        private By countryDropdown = By.Name("countryListboxRegisterPage");
        private By cityTXT = By.Name("cityRegisterPage");
        private By addressTXT = By.Name("addressRegisterPage");
        private By stateTXT = By.Name("state_/_province_/_regionRegisterPage");
        private By postalCodeTXT = By.Name("postal_codeRegisterPage");
        private By offersCheckbox = By.Name("allowOffersPromotion");
        private By agreementCheckbox = By.Name("i_agree");
        private By registerBTN = By.Id("register_btn");
        #endregion

        #region Methods
        public void Register(string url, string username, string email, string password, string confirmPassword,
                             string firstName, string lastName, string phone, string country, string city,
                             string address, string state, string postalCode, bool receiveOffers)
        {
            OpenURL(url);
            Click(menuUser);
            ClickUsingJavaScript(Createaccountbutton);
            Write(usernameTXT, username);
            Write(emailTXT, email);
            Write(passwordTXT, password);
            Write(confirmPasswordTXT, confirmPassword);
            Write(firstNameTXT, firstName);
            Write(lastNameTXT, lastName);
            Write(phoneNumberTXT, phone);
            SelectDropdownByText(countryDropdown, country);
            Write(cityTXT, city);
            Write(addressTXT, address);
            Write(stateTXT, state);
            Write(postalCodeTXT, postalCode);

            if (receiveOffers)
            {
                Click(offersCheckbox);
            }

            Click(agreementCheckbox);

            Thread.Sleep(1000);

            Click(registerBTN);

            Thread.Sleep(1000);

            ValidateRegistration(username);

            Thread.Sleep(1000);
        }

        private void ValidateRegistration(string username)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menuUserLink")));
            try
            {
                IWebElement userNameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='hi-user containMiniTitle ng-binding']")));
                string registeredUser = userNameElement.Text;
                Assert.AreEqual(username, registeredUser, "Registration was not successful; the expected username is not displayed.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("The registration confirmation was not found within the timeout period.");
            }
        }
        #endregion
    }
}
