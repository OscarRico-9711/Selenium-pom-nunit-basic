using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using Practica_selenium___nunit___pom_basic.drivers;
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

		[SetUp]
		public void setUp()
		{

			browser = TestContext.Parameters.Get("browser", "chrome"); // Default: Chrome
			driver = webDriverManager.getDriver(browser);
		}



		public void Dispose() 
		{
			Thread.Sleep(2000);
			webDriverManager.Quitdriver();
		}
	}


}
