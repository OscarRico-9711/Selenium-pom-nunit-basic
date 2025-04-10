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
	public class ButtonsPage : CommonActions
	{
		public ButtonsPage(IWebDriver driver) : base(driver) { }


		public void DoubleClick()
		{

			DoubleClick(ButtonsPageLocators.DoubleClick);
		}

		public void RigthClick()
		{

			RightClick(ButtonsPageLocators.RigthClick);
		}

		public void RegularClick()
		{

			Click(ButtonsPageLocators.RegularClick);

		}

		public string validateTextResultDoubleClick()
		{

			return GetElementText(ButtonsPageLocators.MessageResultDoubleClick);

		}


		public string validateTextResultRigthClick()
		{
			return GetElementText(ButtonsPageLocators.MessageResultRigthClick);
		}

		public string validateTextResultRegularClick()
		{
			return GetElementText(ButtonsPageLocators.MessageResultRegularClick);
		}

	}
}
