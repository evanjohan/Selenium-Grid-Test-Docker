using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumGridTest
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : Hooks
    {
        public FirefoxTesting() : base(BrowserType.Firefox)
        {
        }

        [Test]
        public void FirefoxGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("Selenium Grid" +Keys.Enter);
            System.Threading.Thread.Sleep(5000);
            Assert.That(Driver.PageSource.Contains("Selenium Grid"), Is.EqualTo(true),
                                                    "The Test Selenium Grid Does Not Exist");
        }
    }

    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting() : base(BrowserType.Chrome)
        {
        }

        [Test]
        public void ChromeGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("Docker" + Keys.Enter);
            System.Threading.Thread.Sleep(3000);
            Assert.That(Driver.PageSource.Contains("Docker"), Is.EqualTo(true),
                                                     "The Test Docker Does Not Exist");
            
        }

    }

    [TestFixture]
    [Parallelizable]
    public class IETesting : Hooks
    {
        public IETesting() : base(BrowserType.IE)
        {
        }

        [Test]
        public void IEGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("Kubernetes" + Keys.Enter);
            Assert.That(Driver.PageSource.Contains("Kubernetes"), Is.EqualTo(true),
                                                     "The Test Kubernetes Does Not Exist");

        }

    }

}
