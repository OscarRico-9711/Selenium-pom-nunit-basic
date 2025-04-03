using OpenQA.Selenium;
using Practica_selenium___nunit___pom_basic.locators;
using Practica_selenium___nunit___pom_basic.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.pages
{
	public class ElementsPage : CommonActions
	{
		protected CommonActions commonActions;
		public ElementsPage(IWebDriver driver) : base(driver) {

			commonActions = new CommonActions(driver);


		}

		public string GetCurrentUrl()
		{
			return _driver.Url;
		}

		public void SelectTextBoxOption()
		{
			Click(ElementPageLocators.TextBoxoptions);
		}
		public void SelectSubModule(string subModule) {

			Click(ElementPageLocators.SelectSubModule(subModule));
	
		}

		public void FillFullForm(string fullname, string fullEmail, string fullCurrentAdress)
		{
			SendText(ElementPageLocators.fullname, fullname);
			SendText(ElementPageLocators.fullEmail, fullEmail);
			SendText(ElementPageLocators.fullAdress, fullCurrentAdress);
			Click(ElementPageLocators.SubmitForm);
		}

		public bool ElementIsVisible()
		{
			return ElementIsVisible(ElementPageLocators.Outputform);
		}

		public string GetOutputTextName()
		{
			return GetElementText(ElementPageLocators.Outputname);
		}

		internal string GetOutputTextEmail()
		{
			return GetElementText(ElementPageLocators.OutputEmail);
		}

		internal string GetOutputTextAddress()
		{
			return GetElementText(ElementPageLocators.OutputAdress);
		}

		internal bool ElementIsNotVisible()
		{
			return ElementIsNotVisible(ElementPageLocators.Outputform);
		}

		internal string GetEmailFieldAtribute()
		{
			return getElementattribute("class", ElementPageLocators.fullEmail);
		}
	}
}
