// Generated by Selenium IDE
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit;
public class SuiteTestsTroca : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTestsTroca()
  {
    driver = new EdgeDriver();
        js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
  }
  public void Dispose()
  {
    driver.Quit();
  }
  [Fact]
  public void TelasTroca() {
    driver.Navigate().GoToUrl("https://localhost:44308/");
    driver.Manage().Window.Size = new System.Drawing.Size(1382, 736);
    driver.FindElement(By.CssSelector(".bi-person")).Click();
    driver.FindElement(By.Id("Cpf")).Click();
    driver.FindElement(By.Id("Cpf")).SendKeys("11111111111");
    driver.FindElement(By.CssSelector("button:nth-child(4)")).Click();
    driver.FindElement(By.LinkText("Pedidos")).Click();
    driver.FindElement(By.LinkText("Trocar")).Click();
    driver.FindElement(By.LinkText("Status de troca")).Click();
    driver.FindElement(By.LinkText("Continuar navegando")).Click();
    driver.Close();
  }
}
