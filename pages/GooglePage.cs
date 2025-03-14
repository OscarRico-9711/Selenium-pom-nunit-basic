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
	public class GooglePage : CommonActions
	{

		public GooglePage(IWebDriver driver) : base(driver) { }

		public void OpenUrl()
		{
			OpenUrl("https://perpetuo-beats-page.vercel.app/");
		}

		public void SelectContact()
		{
			Click(googleLocators.ContactOption);
		}



	}
}
;