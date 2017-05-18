using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium_Tests
{
    static class TestExtensions
    {
        public static IWebElement WaitGetElement(this IWebDriver driver, By by, int timeoutInSeconds, bool checkIsVisible = false)
        {
            IWebElement element;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            try
            {
                if (checkIsVisible)
                {
                    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                }
                else
                {
                    element = wait.Until(ExpectedConditions.ElementExists(by));
                }
            }
            catch (NoSuchElementException) { element = null; }
            catch (WebDriverTimeoutException) { element = null; }
            catch (TimeoutException) { element = null; }

            return element;
        }

        public static IWebElement GetElementRowFromTable(IWebDriver driver, string TableID, string TableRowIdentifier) {
            
            IWebElement matchedRow = null;

            IWebElement baseTable = driver.FindElement(By.Id(TableID));
            // gets all table rows
            ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("tr"));

            string cellValue = string.Empty;

            try
            {
                foreach (var row in rows)
                {
                    if (row.FindElements(By.XPath("td/span")).FirstOrDefault(cell => cell.Text.Trim().Equals(TableRowIdentifier)) != null)
                    {
                        matchedRow = row;
                        break;
                    }
                }
            }
            catch (NoSuchElementException)
            {
                //couldnot find 
                matchedRow = null;
            }

            //if (matchedRow != null)
            //{
            //    cellValue = matchedRow.FindElement(By.XPath(string.Format("td[{0}]/span", targetCellIndex)).Text;
            //}

            return matchedRow;
        }

    }
}
