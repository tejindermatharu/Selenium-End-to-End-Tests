using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Selenium_Tests
{
    [Binding]
    public class SpecFlowFeatureAdminScreenSteps
    {
        private const string Key = "testing8";
        private const string Description = "Some Desc";
        private const int Price = 23;

        private const string AddButtonId = "btnSubmitProduct";
        private const string editTableId = "tblProducts";
        private const string nameFieldId = "txtName";
        private const string descFieldId = "txtDescription";
        private const string priceField = "txtPrice";

        private const int timeOut = 5;
        private const string url = "http://localhost:60129/index.html";

        IWebDriver driver;

        [Given(@"I have filled in all the form fields correctly")]
        public void GivenIHaveFilledInAllTheFormFieldsCorrectly()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            //GET ELEMENTS
            var nameInput = driver.WaitGetElement(By.Id(nameFieldId), timeOut, true);
            var descInput = driver.WaitGetElement(By.Id(descFieldId), timeOut, true);
            var priceInput = driver.WaitGetElement(By.Id(priceField), timeOut, true);

            //SET VALUES
            nameInput.SendKeys(Key);
            descInput.SendKeys(Description);
            priceInput.SendKeys(Price.ToString());
        }
        
        [When(@"I click Add")]
        public void WhenIClickAdd()
        {
            //CLICK ADD BUTTON
            driver.FindElement(By.Id(AddButtonId)).Click();
        }
        
        [Then(@"the added entry should appear in the edit grid")]
        public void ThenTheAddedEntryShouldAppearInTheEditGrid()
        {
            //INSPECT TABLE GRID FOR VALUE BASED ON KEY AND RETURN OBJECT IF FOUND
            var doesElememntForRowExist = TestExtensions.GetElementRowFromTable(driver, editTableId, Key);

            Assert.IsNotNull(doesElememntForRowExist);
        }
    }
}
