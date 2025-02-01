using System;
using EcommerceWebsite.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;
namespace EcommerceWebsite
{
    [TestClass]
    public class TestExecution
    {
        public static IWebDriver driver;
        public LoginPage loginPage;
        public RegisterAccount RegisterAccount;
        private AddToCart addToCartPage;
        private Checkout checkout;
        private MenuFunction menuFunction;


        [TestInitialize]
        public void Setup()
        {
            // Initialize the driver
            BasePage.SeleniumInit("Chrome");
            driver = BasePage.driver;
            loginPage = new LoginPage();
            RegisterAccount = new RegisterAccount();
            addToCartPage = new AddToCart();
            checkout = new Checkout();
            menuFunction = new MenuFunction();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestPriority(1)]
        [AllureDescription("Test to verify user registration functionality")]
        public void TestRegister_TC001()
        {
            // Test data
            string username = "zeeshaniya";
            string email = "zeeshan@example.com";
            string password = "Zeeshan@123";
            string confirmPassword = "Zeeshan@123";
            string firstName = "Zeeshan";
            string lastName = "Mustafa";
            string phone = "1234567890";
            string country = "Pakistan";
            string city = "Karachi";
            string address = "123 Main Street";
            string state = "Sindh";
            string postalCode = "74000";
            bool receiveOffers = true;

            string Url = "https://advantageonlineshopping.com/#/";

            RegisterAccount.Register(Url, username, email, password, confirmPassword,
                                      firstName, lastName, phone, country, city,
                                      address, state, postalCode, receiveOffers);
        }

        [TestMethod]
        [TestPriority(2)]
        [AllureDescription("Test to verify user")]
        public void TestLogin_TC002()
        {
            string username = "zeeshaniya";
            string password = "Zeeshan@123";
            string Url = "https://advantageonlineshopping.com/#/";
            loginPage.Login(Url, username, password);
        }

        [TestMethod]
        [TestPriority(3)]
        [AllureDescription("Test to verify invalid user")]
        public void TestLoginInvalid_TC003()
        {
            string username = "kumail";
            string password = "kusdkjn";
            string Url = "https://advantageonlineshopping.com/#/";

            loginPage.Login(Url, username, password);

            try
            {
                string error = BasePage.driver.FindElement(By.Id("signInResultMessage")).Text;
                Assert.AreEqual(error, "OR");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Login Successful");
            }
        }

        [TestMethod]
        [AllureDescription("Test to verify Add to Cart functionality")]
        public void TestAddToCart_TC004()
        {
            string username = "zeeshaniya";
            string password = "Zeeshan@123";
            string Url = "https://advantageonlineshopping.com/#/";
            loginPage.Login(Url, username, password);
            addToCartPage.addToCart();
        }

        [TestMethod]
        [AllureDescription("Test to add to cart and checkout with SafePay")]
        public void TestCheckOut_TC005()
        {
            string username = "zeeshaniya";
            string password = "Zeeshan@123";
            string payType = "SafePay";
            string Url = "https://advantageonlineshopping.com/#/";

            loginPage.Login(Url, username, password);
            addToCartPage.addToCart();
            if (payType == "SafePay")
            {
                string firstName = "Kumail";
                string lastName = "Raza";
                string phoneNum = "1234567890";
                string country = "Pakistan";
                string city = "Karachi";
                string address = "Defence";
                string postalCode = "2345";
                string state = "Sindh";
                string paymentType = "SafePay";
                string safePayUserName = "kumail";
                string safePayPassword = "kumailPay1";

                checkout.checkOutSafePay(firstName, lastName, phoneNum, country, city, address, postalCode, state,
                                                  paymentType, safePayUserName, safePayPassword);
            }
            else if (payType == "Master")
            {
                string firstName = "Kumail";
                string lastName = "Raza";
                string phoneNum = "1234567890";
                string country = "Pakistan";
                string city = "Karachi";
                string address = "Defence";
                string postalCode = "2345";
                string state = "Sindh";
                string paymentType = "Master";
                string cardNum = "4886777788889999";
                string cvv = "2322";
                string month = "09";
                string year = "2030";
                string cardHolderName = "Kumail Raza";

                checkout.checkOutMaster(firstName, lastName, phoneNum, country, city, address, postalCode, state,
                                                  paymentType, cardNum, cvv, month, year, cardHolderName);
            }
        }


        [TestMethod]
        [AllureDescription("Test to verify user registration functionality with master card")]
        public void TestCheckOut_TC006()
        {
            string username = "zeeshaniya";
            string password = "Zeeshan@123";
            string payType = "Master";
            string Url = "https://advantageonlineshopping.com/#/";

            loginPage.Login(Url, username, password);
            addToCartPage.addToCart();
            if (payType == "SafePay")
            {
                string firstName = "Kumail";
                string lastName = "Raza";
                string phoneNum = "1234567890";
                string country = "Pakistan";
                string city = "Karachi";
                string address = "Defence";
                string postalCode = "2345";
                string state = "Sindh";
                string paymentType = "SafePay";
                string safePayUserName = "kumail";
                string safePayPassword = "kumailPay1";

                checkout.checkOutSafePay(firstName, lastName, phoneNum, country, city, address, postalCode, state,
                                                  paymentType, safePayUserName, safePayPassword);
            }
            else if (payType == "Master")
            {
                string firstName = "Kumail";
                string lastName = "Raza";
                string phoneNum = "1234567890";
                string country = "Pakistan";
                string city = "Karachi";
                string address = "Defence";
                string postalCode = "2345";
                string state = "Sindh";
                string paymentType = "Master";
                string cardNum = "4886777788889999";
                string cvv = "2322";
                string month = "09";
                string year = "2030";
                string cardHolderName = "Kumail Raza";

                checkout.checkOutMaster(firstName, lastName, phoneNum, country, city, address, postalCode, state,
                                                  paymentType, cardNum, cvv, month, year, cardHolderName);
            }
        }

        [TestMethod]
        [AllureDescription("Test to Signout")]
        public void TestSignout_TC007()
        {
            string username = "zeeshaniya";
            string password = "Zeeshan@123";
            string Url = "https://advantageonlineshopping.com/#/";
            loginPage.Login(Url, username, password);
            Thread.Sleep(1000);
            menuFunction.signout();
        }

        [TestMethod]
        [AllureDescription("Test to deleting account")]
        public void TestDelete_TC008()
        {
            string username = "arqam";
            string password = "Arqam123";
            string Url = "https://advantageonlineshopping.com/#/";
            loginPage.Login(Url, username, password);
            Thread.Sleep(1000);
            menuFunction.deleteaccount();

        }



        [TestCleanup]
        public void TearDown()
        {
            BasePage.driver.Close();
        }

    }
}

