using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Practica_selenium___nunit___pom_basic.locators;
using Practica_selenium___nunit___pom_basic.utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.pages
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