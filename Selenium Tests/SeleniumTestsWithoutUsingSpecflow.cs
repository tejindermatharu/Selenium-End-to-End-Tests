using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Tests
{
    [TestFixture]
    public class SeleniumTestsWithoutUsingSpecflow
    {                
        private const string Key = "testing5";
        private const string Description = "Some Desc";
        private const int Price = 23;

        private const string AddButtonId = "btnSubmitProduct";
        private const string editTableId = "tblProducts";
        private const string nameFieldId = "txtName";
        private const string descFieldId = "txtDescription";
        private const string priceField = "txtPrice";

        private const int timeOut = 5;
        private const string url = "http://localhost:60129/index.html";

        [Test]
        public void WhenUserFillsOutForm_ThenClicksSubmitButton_ShouldCreateARowInTheEditGrid()
        { 
            using (IWebDriver driver = new ChromeDriver())
            {
               // driver.Manage().Window.Maximize();
             
                driver.Navigate().GoToUrl(url);

                //GET ELEMENTS
                var nameInput = driver.WaitGetElement(By.Id(nameFieldId), timeOut, true);
                var descInput = driver.WaitGetElement(By.Id(descFieldId), timeOut, true);
                var priceInput = driver.WaitGetElement(By.Id(priceField), timeOut, true);

                //SET VALUES
                nameInput.SendKeys(Key);
                descInput.SendKeys(Description);
                priceInput.SendKeys(Price.ToString());

                //CLICK ADD BUTTON
                driver.FindElement(By.Id(AddButtonId)).Click();

                //WAIT
                System.Threading.Thread.Sleep(2000);
                
                //INSPECT TABLE GRID FOR VALUE BASED ON KEY AND RETURN OBJECT IF FOUND
                var doesElememntForRowExist = TestExtensions.GetElementRowFromTable(driver, editTableId, Key);
                
                Assert.IsNotNull(doesElememntForRowExist);             
            }
        }        
    }
}
