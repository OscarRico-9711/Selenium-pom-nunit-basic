using Allure.NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using Practica_selenium___nunit___pom_basic.drivers;
using Practica_selenium___nunit___pom_basic.pages;
using Practica_selenium___nunit___pom_basic.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.hooks
{


	
	public class testHooks : IDisposable
	{
		private string browser;
		protected IWebDriver driver;
		protected webDriverManager _webDriverManager;

		protected CommonActions _commonActions;
	


		[OneTimeSetUp]
		public void OneTimeSetUp()
		{

			_webDriverManager = new webDriverManager();
			browser = TestContext.Parameters.Get("browser", "chrome"); // Default: Chrome
			driver = _webDriverManager.getDriver(browser);
			_commonActions = new CommonActions(driver);

		}

		[TearDown]
		public void TearDown()
		{

			if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
			{
				_commonActions.TakeScreenshoot();				
			}
			else
			{
				Console.WriteLine($"{TestContext.CurrentContext.Test.Name} : {TestContext.CurrentContext.Result.Outcome.Status}");
			}

			_commonActions.ClearCookiesAndStorages();


		}


		[OneTimeTearDown]
		public void OneTimeTearDown()
		{

			Dispose();

		}

		public void Dispose()
		{

			_webDriverManager.Quitdriver();
		}


	}


}