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
	public class HomePage : CommonActions
	{


		public HomePage(IWebDriver driver) : base(driver){}

		public void OpenURL(string url)
		{
			OpenUrl(url);
		}

		public void SelectModule(string module)
		{
			Click(HomePageLocators.GetModule(module));
		}




	}
}
;