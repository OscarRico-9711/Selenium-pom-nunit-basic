using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.drivers
{
	public class webDriverManager
	{

		private static IWebDriver driver;

		public static IWebDriver getDriver()
		{
			if (driver == null)
			{
				driver = new ChromeDriver();
				driver.Manage().Window.Maximize();
			}

			return driver;

		}
		public static void Quitdriver()
		{
			if (driver != null)
			{
				driver.Quit();  // Cierra el navegador.				
				driver = null;   // Evita referencias colgantes.
			}
		}

	}
}
