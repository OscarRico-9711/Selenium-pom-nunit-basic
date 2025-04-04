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
