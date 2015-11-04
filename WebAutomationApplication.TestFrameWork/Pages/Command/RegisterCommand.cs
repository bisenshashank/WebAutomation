using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationApplication.TestFrameWork.Selenium;

namespace WebAutomationApplication.TestFrameWork.Pages.Command
{
    public class RegisterCommand
    {
        private string emailId;
        private string password;
        private string confirmPassword;
        
        public RegisterCommand(string emailId)
        {
            this.emailId = emailId;
        }

        public RegisterCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public RegisterCommand WithConfirmPassword(string confirmPassword)
        {
            this.confirmPassword = confirmPassword;
            return this;
        }

        public void Register()
        {
            IWebElement emailInput = Driver.Instance.FindElement(By.Id("Email"));
            emailInput.SendKeys(emailId);

            IWebElement passwordInput = Driver.Instance.FindElement(By.Id("Password"));
            passwordInput.SendKeys(password);

            IWebElement confirmPasswordInput = Driver.Instance.FindElement(By.Id("ConfirmPassword"));
            confirmPasswordInput.SendKeys(confirmPassword);

            IWebElement signupButton = Driver.Instance.FindElement(By.ClassName("btn"));
            signupButton.Click();
        }
    }
}
