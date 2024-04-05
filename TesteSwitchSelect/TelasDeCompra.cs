using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit;


namespace TesteSwitchSelect
{
    public class SuiteTests : IDisposable
    {
        public IWebDriver driver { get; private set; }
        public IDictionary<string, object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }

        public SuiteTests()
        {
            driver = new EdgeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void TelasDeCompra()
        {
            driver.Navigate().GoToUrl("https://localhost:44308/");
            driver.Manage().Window.Size = new System.Drawing.Size(1382, 736);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.CssSelector(".text-decoration-none > .img-fluid")).Click();
            driver.FindElement(By.Id("adicionarCarrinho")).Click();
            driver.FindElement(By.LinkText("Ver Carrinho")).Click();
            driver.FindElement(By.LinkText("Finalizar Pedido")).Click();
            driver.FindElement(By.LinkText("Continuar")).Click();
            driver.FindElement(By.LinkText("Confirmar pedido")).Click();
            driver.FindElement(By.LinkText("Continuar Comprando")).Click();
            driver.Close();
        }
    }
}
