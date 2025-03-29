using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.utilities
{
	public class CommonActions
	{

		protected readonly WebDriverWait _wait;
		protected readonly IWebDriver _driver;
		

		public CommonActions(IWebDriver driver)
		{
			_driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			
		}

		public void ClearCookiesAndStorages()
		{
			_driver.Manage().Cookies.DeleteAllCookies();
			((IJavaScriptExecutor)_driver).ExecuteScript("window.localStorage.clear();"); // Limpiar local storage
			((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.clear();"); // Limpiar session storage
			Console.WriteLine("Enviroment clean");
		}
		public IWebElement FindElement(By locator)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(locator));

			return _driver.FindElement(locator);
		}

		public void OpenUrl(string Url)
		{
			_driver.Navigate().GoToUrl(Url);
		}

		public void Click(By locator)
		{
			_wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();	
		}


		public void DoubleClick(By locator)
		{
			IWebElement element = FindElement((locator));
			Actions action = new Actions(_driver);
			action.DoubleClick(element).Perform();
		}

		public void SendText(By locator, String text)
		{
			FindElement(locator).Clear();
			FindElement(locator).SendKeys(text);
		}

		public void sendenter(By locator)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(locator)).FindElement(locator).SendKeys(Keys.Enter);
		}

		public string GetElementText(By locator)
		{
			return FindElement(locator).Text;
		}

		public string GetElementAtribute(By locator, string atribute)
		{
			return FindElement(locator).GetAttribute(atribute);
		}


		public bool ElementIsVisible(By locator)
		{
			try
			{
				_wait.Until(ExpectedConditions.ElementIsVisible(locator));
				return true;
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
		}

		public bool ElementIsNotVisible(By locator)
		{
			try
			{
				return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
			}
			catch (WebDriverTimeoutException)
			{
				return false; // Si el tiempo expira, el elemento sigue visible
			}
		}

		public void TakeScreenshoot()
		{
			string nametest = $"{TestContext.CurrentContext.Test.Name}";

			//create folder
			string screenshotsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShoots");

			//validate if folder exist before to create it
			if (!Directory.Exists(screenshotsFolder))
			{

				Directory.CreateDirectory(screenshotsFolder);

			}

			//take screenshot

			var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();


			//save screenshot

			string screenshotpath = Path.Combine(screenshotsFolder, $"{nametest}_{DateTime.Now:yyMMdd_HHmmss}.png");

			screenshot.SaveAsFile(screenshotpath);

			Console.WriteLine($"screenshoot save in {screenshotpath}");
		}


		public string getElementattribute(string atribute, By locator)
		{

			return FindElement(locator).GetAttribute(atribute);

		}



	}
}
