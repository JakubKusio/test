
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
public class SuiteTests : IDisposable
{
    public IWebDriver driver { get; private set; }
    public IDictionary<String, Object> vars { get; private set; }
    public IJavaScriptExecutor js { get; private set; }
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
    public void Test2()
    {
        driver.Navigate().GoToUrl("https://www.medicalgorithmics.pl/");
        driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
        driver.FindElement(By.CssSelector(".side_menu_button")).Click();
        driver.FindElement(By.CssSelector(".icon_search")).Click();
        driver.FindElement(By.Name("s")).Click();
        driver.FindElement(By.Name("s")).SendKeys("Pocket ECG CRS");
        driver.FindElement(By.CssSelector(".arrow_right")).Click();
    }

    [Fact]
    public void calculate()
    {
        List<WebElement> rows = driver.findElements(By.xpath("/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul"));
        log.info("Number: " + rows.size());
    }

        [Fact]
    public void displayValue() {
        Boolean Display = driver.findElement(By.xpath("/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div[2]")).isDisplayed();
        log.info("Number: " + Display());
    }  
    
    }
 

