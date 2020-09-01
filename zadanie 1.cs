
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
using System.IO;

public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}

    public SuiteTests()
  {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
    }
  public void Dispose()
  {
    driver.Quit();
  }
  [Fact]
  public void Cscs() {
    driver.Navigate().GoToUrl("https://www.medicalgorithmics.pl/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 726);
    driver.FindElement(By.CssSelector(".main_menu > #mega-menu-wrap-top-navigation #mega-menu-item-29 > .mega-menu-link")).Click();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        driver.FindElement(By.LinkText("Media pack")).Click();
  }
    
        public void VerifyFileDownload()
    {
        string expectedFilePath = @"C:\Downloads\logotypy.zip";
        bool fileExists = false;

        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\Downloads");
        var driver = new ChromeDriver(chromeOptions);

        driver.Navigate().GoToUrl("https://www.medicalgorithmics.pl/");
        driver.Manage().Window.Size = new System.Drawing.Size(1366, 726);
        driver.FindElement(By.CssSelector(".main_menu > #mega-menu-wrap-top-navigation #mega-menu-item-29 > .mega-menu-link")).Click();
        driver.FindElement(By.LinkText("Media pack")).Click();

        try
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
          

            Console.WriteLine("File exists : " + fileExists);

            FileInfo fileInfo = new FileInfo(expectedFilePath);


            Assert.Equal(1517, fileInfo.Length);
            Assert.Equal("logotypy.zip", fileInfo.Name);
            Assert.Equal(@"C:\Downloads\logotypy.zip", fileInfo.FullName);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (File.Exists(expectedFilePath))
                File.Delete(expectedFilePath);

        }
        driver.Quit();
    }

}
