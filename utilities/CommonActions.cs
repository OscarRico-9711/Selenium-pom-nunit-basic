using OpenQA.Selenium;
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

		private readonly WebDriverWait _wait;
		private readonly IWebDriver _driver;

		public CommonActions(IWebDriver driver)
		{	
			_driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		public void OpenUrl(string Url)
		{
			_driver.Navigate().GoToUrl(Url);
		}

		public void Click(By locator)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(locator)).FindElement(locator).Click();
		}

		public void SendText(IWebDriver driver, By locator, String text)
		{

			_wait.Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);

		}

		public void sendenter(IWebDriver driver, By locator)
		{
			_wait.Until(ExpectedConditions.ElementIsVisible(locator)).FindElement(locator).SendKeys(Keys.Enter);
		}
	}
}
