using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Practica_selenium___nunit___pom_basic.drivers
{
	public class webDriverManager
	{

		private static IWebDriver driver;

		public static IWebDriver getDriver(String browser)
		{
			if (driver == null)
			{
				if (browser.ToLower() == "chrome")
				{
					new DriverManager().SetUpDriver(new ChromeConfig());  // Descarga y configura ChromeDriver
					driver = new ChromeDriver();
				}
				else if (browser.ToLower() == "firefox")
				{
					new DriverManager().SetUpDriver(new FirefoxConfig());  // Descarga y configura GeckoDriver
					driver = new FirefoxDriver();
				}
				else
				{
					throw new ArgumentException("Navegador no soportado: " + browser);
				}

				driver.Manage().Window.Maximize();
			}

			return driver;

		}
		public static void Quitdriver()
		{
			if (driver != null)
			{
				driver.Quit();     // Cierra el navegador  				
				driver = null;
			}
		}

	}
}
