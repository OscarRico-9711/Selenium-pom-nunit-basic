using OpenQA.Selenium;
using PracticaNunitAllureJenkins1.locators;
using PracticaNunitAllureJenkins1.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.pages
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
