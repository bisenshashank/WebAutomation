using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationApplication.TestFrameWork.Selenium;

namespace WebAutomationApplication.TestFrameWork.Pages
{
    public class HomePage
    {
        public static string GreetingMessage
        {
            get
            {
                var greetingMessage = string.Empty;
                var div = Driver.Instance.FindElement(By.Id("logoutForm"));

                var lis = div.FindElements(By.TagName("li"));
                if (lis != null && lis.Any())
                {
                    greetingMessage = lis.First().Text;
                }
                return greetingMessage;
            }
        }
    }
}
