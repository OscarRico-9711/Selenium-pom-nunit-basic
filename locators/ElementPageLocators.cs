using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.locators
{
	public class ElementPageLocators
	{
		public static By TextBoxoptions = By.XPath("//div[@class='element-list collapse show']//span[text()='Text Box']");

		public static By SelectSubModule(string subModule) {

			return By.XPath($"//div[@class='element-list collapse show']//span[text()='{subModule}']");
		}

		public static By TextBoxtitle = By.XPath("//h1[contains(text(), \"Text\")]");

		public static By fullname = By.XPath("//form//input[@id='userName']");

		public static By fullEmail = By.XPath("//form//input[@id='userEmail']");

		public static By fullAdress = By.XPath("//form//textarea[@id='currentAddress']");

		public static By SubmitForm = By.XPath("//button[@id='submit']");

		public static By Outputform = By.XPath("//div[@id='output']");

		public static By Outputname = By.XPath("//div[@id='output']/descendant::p[@id='name']");

		public static By OutputEmail = By.XPath("//div[@id='output']/descendant::p[@id='email']");
		public static By OutputAdress = By.XPath("//div[@id='output']/descendant::p[@id='currentAddress']");
	}
}
