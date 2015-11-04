using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAutomationApplication.TestFrameWork.Selenium;
using WebAutomationApplication.TestFrameWork;
using WebAutomationApplication.TestFrameWork.Pages;

namespace WebAutomationApplication.Test
{
    [TestClass]
    public class RegisterPageTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }

        [TestMethod]
        public void User_Submit_Empty()
        {
            RegisterPage.Goto();

            RegisterPage.WithEmailId(string.Empty)
                .WithPassword(string.Empty)
                .WithConfirmPassword(string.Empty)
                .Register();

            CollectionAssert.Contains(RegisterPage.Errors, "The Email field is required.");
            CollectionAssert.Contains(RegisterPage.Errors, "The Password field is required.");
        }

        [TestMethod]
        public void User_Submit_Incorrect_EmailId()
        {
            RegisterPage.Goto();

            RegisterPage.WithEmailId("shashank")
                .WithPassword("password")
                .WithConfirmPassword("password")
                .Register();

            CollectionAssert.Contains(RegisterPage.Errors, "The Email field is not a valid e-mail address.");
        }

        [TestMethod]
        public void User_Submit_Different_Password_And_ConfirmPassword()
        {
            RegisterPage.Goto();

            RegisterPage.WithEmailId("test@gmail.com")
                .WithPassword("password")
                .WithConfirmPassword("password1")
                .Register();

            CollectionAssert.Contains(RegisterPage.Errors, "The password and confirmation password do not match.");
        }
        
        [TestMethod]
        public void User_Submit_Small_Password()
        {
            RegisterPage.Goto();

            RegisterPage.WithEmailId("test@gmail.com")
                .WithPassword("key")
                .WithConfirmPassword("key")
                .Register();

            CollectionAssert.Contains(RegisterPage.Errors, "The Password must be at least 6 characters long.");
        }

        [TestMethod]
        public void User_Submit_Invalid_Password()
        {
            RegisterPage.Goto();

            RegisterPage.WithEmailId("test@gmail.com")
                .WithPassword("password")
                .WithConfirmPassword("password")
                .Register();

            CollectionAssert.Contains(RegisterPage.Errors, "Passwords must have at least one non letter or digit character. Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z').");
        }

        [TestMethod]
        public void User_Submit_Valid_Data()
        {
            var emailId = string.Format("test{0}@gmail.com", Guid.NewGuid());
            RegisterPage.Goto();

            RegisterPage.WithEmailId(emailId)
                .WithPassword("Password@2015")
                .WithConfirmPassword("Password@2015")
                .Register();

            Assert.AreEqual(HomePage.GreetingMessage, string.Format("Hello {0}!", emailId));
        }
    }
}
