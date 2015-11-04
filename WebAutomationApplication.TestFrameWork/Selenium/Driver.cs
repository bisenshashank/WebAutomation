using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Threading;


namespace WebAutomationApplication.TestFrameWork.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance;

        public static string BaseAddress
        {
            get
            {
                return "http://localhost:39430/";
            }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
