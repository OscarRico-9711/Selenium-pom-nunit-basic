using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using Practica_selenium___nunit___pom_basic.drivers;
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
		protected IWebDriver driver;
		private string browser;
		private CommonActions _commonActions;

		[SetUp]
		public void setUp()
		{

			browser = TestContext.Parameters.Get("browser", "chrome"); // Default: Chrome
			driver = webDriverManager.getDriver(browser);
			_commonActions = new CommonActions(driver);
		}

		[TearDown]
		public void TearDown()
		{

			if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
			{
				

				_commonActions.TakeScreenshoot();

				Thread.Sleep(2000);
			}
			else {
			
			Console.WriteLine($"{TestContext.CurrentContext.Test.Name} : {TestContext.CurrentContext.Result.Outcome.Status}");


			}

		}

		public void Dispose()
		{

			webDriverManager.Quitdriver();
		}


	}


}
