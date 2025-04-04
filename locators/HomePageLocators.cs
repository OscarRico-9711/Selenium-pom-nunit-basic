using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.locators
{
	public class HomePageLocators
	{
		public static By ContactOption = By.XPath("//nav[@class=' header options']//a[text()='CONTACT']");

		public static By ElemetsModuleOption = By.XPath("//div[@class='category-cards']/descendant::h5[text()='Elements']");

		public static By GetModule(string module)
		{
			return By.XPath($"//div[@class='category-cards']/descendant::h5[text()='{module}']");
		}

		public static By TextBoxoptions = By.XPath("//div[@class='element-list collapse show']//span[text()='Text Box']");

		public static By TextBoxtitle = By.XPath("//h1[contains(text(), \"Text\")]");

		public static By fullname = By.XPath("//form//input[@id='userName']");

		public static By fullEmail = By.XPath("//form//input[@id='userEmail']");

		public static By fullAdress = By.XPath("//form//textarea[@id='currentAddress']");

		public static By SubmitForm = By.XPath("//button[@id='submit']");

		public static By Outputform = By.XPath("//div[@id='output']");

		public static By Outputname = By.XPath("//div[@id='output']/descendant::p[@id='name']");

		public static By OutputEmail = By.XPath("//div[@id='output']/descendant::p[@id='email']");




	}

}



