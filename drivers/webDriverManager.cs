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
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Practica_selenium___nunit___pom_basic.drivers
{
	public class webDriverManager
	{

		private IWebDriver? driver;

		public IWebDriver getDriver(String browser)
		{
			if (driver == null)
			{
				// Leer la configuración desde el JSON
				bool isHeadless = GetHeadlessConfig();

				if (browser.ToLower() == "chrome")
				{
					new DriverManager().SetUpDriver(new ChromeConfig());
					ChromeOptions options = new ChromeOptions();
					options.AddArgument("--no-sandbox");
					options.AddArgument("--disable-dev-shm-usage");

					if (isHeadless)
					{
						options.AddArgument("--headless"); 					}

					driver = new ChromeDriver(options);

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
		public void Quitdriver()
		{
			if (driver != null)
			{
				driver.Quit();     // Cierra el navegador  				
				driver = null;
			}
		}

		public static bool GetHeadlessConfig()
		{

			try
			{
				string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

				string jsonPath = Path.Combine(baseDirectory, "AppSettings.json");

				string jsontext = File.ReadAllText(jsonPath);
				JObject config = JObject.Parse(jsontext);
				return config["headless"]?.ToObject<bool>() ?? false;
			}
			catch (Exception)
			{

				return false;
			}


		}

		


	}
}