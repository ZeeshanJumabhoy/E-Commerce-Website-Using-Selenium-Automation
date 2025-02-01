# 🛒 Automation Testing for Ecommerce Website & Mobile Application  

This project focuses on **automation testing** for an **ecommerce website** ([AvantageOnlineShopping.com](#)) and a **mobile game application (Toucher)**. The goal is to ensure **functionality, reliability, and performance** through automated test cases.  

## 🚀 Key Features  

### 🏬 Ecommerce Website Testing  
- **Automated end-to-end testing** for key scenarios including:  
  - **User registration & login** (valid and invalid credentials).  
  - **Add-to-cart & checkout processes** (SafePay & MasterCard).  
  - **Account management** (sign-out & account deletion).  

### 📱 Mobile Application Testing  
- **Automated testing** for core **Toucher Mobile Game** features:  
  - **Login functionality**.  
  - **Score tracking & adding friends**.  

### 🛠️ Testing Framework & Tools  
- **Built with Selenium WebDriver** using **C# (.NET Framework) & Visual Studio Code**.  
- **Page Object Model (POM)** implemented for **code reusability, maintainability**, and a clear separation of concerns.  
- **Allure Reporting** for **detailed test execution insights & debugging**.  

---

## 🏗️ System Architecture  
- **BasePage**: Contains generic functions for interacting with web elements.  
- **Page Classes**: Separate classes for each feature (**LoginPage, RegisterAccount, AddToCart**).  
- **Test Execution**: Manages **test initialization, execution, and validation**.  

---

## 💻 Technologies Used  
- **Selenium WebDriver**  
- **C# (.NET Framework)**  
- **Visual Studio Code**  
- **Allure Reporting**  
- **Page Object Model (POM)**  

---

## ▶️ How to Run the Tests  

### 1️⃣ Clone the Repository  
git clone https://github.com/your-username/your-repo-name.git

### 2️⃣ Open the Project in Visual Studio Code

### 3️⃣ Install Required Dependencies
dotnet restore

### 4️⃣ Run the Tests
dotnet test

### 5️⃣ Generate Allure Reports
allure serve ./allure-results

# 📌 Conclusion
This project demonstrates a robust automation testing approach using POM and Allure Reporting. It ensures high-quality functionality for both the ecommerce website and mobile application, significantly reducing manual testing efforts while improving development efficiency.
