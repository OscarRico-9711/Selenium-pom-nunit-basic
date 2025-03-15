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

		public HomePage(IWebDriver driver) : base(driver) { }

		public void OpenURL(string url)
		{
			OpenUrl(url);
		}

		public void SelectElemetsModule()
		{
			Click(HomePageLocators.ElemetsModuleOption);
		}

		public string GetCurrentUrl()
		{
			return _driver.Url;
		}

		public void SelectTextBoxOption()
		{
			Click(HomePageLocators.TextBoxoptions);
			string title = GetElementText(HomePageLocators.TextBoxoptions);
		}
		public bool ElementIsVisible()
		{
			return ElementIsVisible(HomePageLocators.Outputform);
		}

		public void FillFullForm(string fullname, string fullEmail, string fullAdress)
		{
			SendText(HomePageLocators.fullname, fullname);
			SendText(HomePageLocators.fullEmail, fullEmail);
			SendText(HomePageLocators.fullAdress, fullAdress);
			Click(HomePageLocators.SubmitForm);
		}

		public string GetOutputTextName()
		{
			return GetElementText(HomePageLocators.Outputname);
		}

		public string GetOutputTextEmail()
		{
			return GetElementText(HomePageLocators.OutputEmail);
		}

		public string GetOutputTextAddress()
		{
			return GetElementText(HomePageLocators.OutputcurrentAdress);
		}


	}
}
;