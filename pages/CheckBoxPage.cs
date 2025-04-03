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
	internal class CheckBoxPage : CommonActions
	{

		public CheckBoxPage(IWebDriver driver) : base(driver) { }


		public void SelectCheckBox()
		{

			Click(CheckBoxPageLocators.CheckBox);

		}

		public string Validateischecked()
		{

			return getElementattribute("class", CheckBoxPageLocators.CheckBox);

		}

		public string validateMessage() {

			return GetElementText(CheckBoxPageLocators.Confirmation);
		}


	}
}
