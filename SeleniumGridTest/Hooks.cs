using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;


namespace SeleniumGridTest
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }

   [TestFixture]
   public class Hooks:Base
    {
        private BrowserType _browserType;

        public Hooks( BrowserType browser)
        {
            _browserType = browser; 
        }

        [SetUp]
        public void InitTest() => DriverInstance(_browserType);

        private void DriverInstance(BrowserType browserType)
        {
            #region Local
            //if (browserType == BrowserType.Chrome)
            //    Driver = new ChromeDriver();
            //else if (browserType == BrowserType.Firefox)
            //    Driver = new FirefoxDriver();
            //else if (browserType == BrowserType.IE)
            //    Driver = new InternetExplorerDriver();
            #endregion

            #region remote control
            if (browserType == BrowserType.Chrome)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("intl.accept_languages", "en");
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                Driver = new RemoteWebDriver(new Uri("http://localhost:4446/wd/hub"), chromeOptions);
            }
            else if (browserType == BrowserType.Firefox)
            {
                var firefoxOptions = new FirefoxOptions();
                Driver = new RemoteWebDriver(new Uri("http://localhost:4446/wd/hub"), firefoxOptions);
            }
            #endregion
        }

        #region Close Web Automatic
        [TearDown]
        public void cleanup()
        {
            Driver.Quit();
        }
        #endregion


    }

}
