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
	public class RadioButtonPage : CommonActions
	{

		public RadioButtonPage(IWebDriver driver) : base(driver) { }


		public void selectRadioButton()
		{
			Click(RadioButtonPageLocators.CheckElement);
			Thread.Sleep(2000);
		}		

		public string ValidateText()
		{

			return GetElementText(RadioButtonPageLocators.SuccessMesage);

		}
	}
}
