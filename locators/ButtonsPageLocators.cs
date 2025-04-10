using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.locators
{
	public class ButtonsPageLocators
	{
		public static By DoubleClick = By.XPath("//button[@id='doubleClickBtn']");

		public static By RigthClick = By.XPath("//button[@id='rightClickBtn']");

		public static By RegularClick = By.XPath("//button[text()='Click Me']");

		public static By MessageResultDoubleClick = By.XPath("//p[@id='doubleClickMessage']");

		public static By MessageResultRigthClick = By.XPath("//p[@id='rightClickMessage']");

		public static By MessageResultRegularClick = By.XPath("//p[@id='dynamicClickMessage']");



	}
}
