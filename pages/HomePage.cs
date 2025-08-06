using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticaNunitAllureJenkins1.locators;
using PracticaNunitAllureJenkins1.utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.pages
{
	public class HomePage
	{
		private readonly IWebDriver _driver;
		private readonly CommonActions _commonActions;

		public HomePage(IWebDriver driver)
		{
			_driver = driver;
			_commonActions = new CommonActions(_driver);
		}

		public void OpenURL(string url)
		{
			_commonActions.OpenUrl(url);
		}

		public void SelectModule(string module)
		{
			_commonActions.Click(HomePageLocators.GetModule(module));
		}




	}
}
;