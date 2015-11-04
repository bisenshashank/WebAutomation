using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationApplication.TestFrameWork.Pages.Command;
using WebAutomationApplication.TestFrameWork.Selenium;

namespace WebAutomationApplication.TestFrameWork.Pages
{
    public class RegisterPage
    {
        private static List<string> errors;

        public static List<string> Errors
        {
            get
            {
                errors = new List<string>();
                var ul = Driver.Instance.FindElement(By.CssSelector("div.validation-summary-errors ul"));

                var lis = ul.FindElements(By.TagName("li"));
                foreach (var li in lis)
                {
                    errors.Add(li.Text);
                }
                return errors;
            }
        }

        public static void Goto()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "Account/Register");
        }

        public static RegisterCommand WithEmailId(string emailId)
        {
            return new RegisterCommand(emailId);
        }
    }
}
