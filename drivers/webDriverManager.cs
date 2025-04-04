using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using PracticaNunitAllureJenkins1.utilities;
using System;
using PracticaNunitAllureJenkins1.Config;

namespace PracticaNunitAllureJenkins1.drivers
{
	public class webDriverManager
	{
		private IWebDriver? driver;

		public IWebDriver getDriver()
		{
			if (driver == null)
			{
				switch (ConfigHelper.Browser.ToLower())
				{
					case "chrome":
						driver = SetupChromeDriver();
						break;
					case "firefox":
						driver = SetupFirefoxDriver();
						break;
					case "edge":
						driver = SetupEdgeDriver();
						break;
					default:
						throw new ArgumentException($"Unsupported browser: {ConfigHelper.Browser}");
				}

				driver.Manage().Window.Maximize();
			}

			return driver;
		}

		public void QuitDriver()
		{
			driver?.Quit();
			driver = null;
		}

		private IWebDriver SetupChromeDriver()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--no-sandbox", "--disable-dev-shm-usage");
			if (ConfigHelper.IsHeadless) options.AddArgument("--headless");

			return new ChromeDriver(options);
		}

		private IWebDriver SetupFirefoxDriver()
		{
			new DriverManager().SetUpDriver(new FirefoxConfig());
			FirefoxOptions options = new FirefoxOptions();
			if (ConfigHelper.IsHeadless) options.AddArgument("--headless");

			return new FirefoxDriver(options);
		}

		private IWebDriver SetupEdgeDriver()
		{
			new DriverManager().SetUpDriver(new EdgeConfig());
			EdgeOptions options = new EdgeOptions();
			if (ConfigHelper.IsHeadless) options.AddArgument("headless");

			return new EdgeDriver(options);
		}
	}
}
