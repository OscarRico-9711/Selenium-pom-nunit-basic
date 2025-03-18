using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.locators
{
	public class CheckBoxPageLocators
	{

		public static By CheckBox = By.XPath("//span[@class='rct-checkbox']");

		public static By Confirmation = By.XPath($"//div[@id='result']//span[contains(text(),'You have selected :')]");
		

		
	}
}
