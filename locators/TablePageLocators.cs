using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.locators
{
	public class TablePageLocators
	{
		public static By AddButton = By.XPath("//button[@id='addNewRecordButton']");
		public static By Modal = By.XPath("//div[@class='modal-content']");
		public static By name = By.XPath("//div[@class='modal-content']//input[@id='firstName']");
		public static By last = By.XPath("//div[@class='modal-content']//input[@id='lastName']");
		public static By email = By.XPath("//div[@class='modal-content']//input[@id='userEmail']");
		public static By age = By.XPath("//div[@class='modal-content']//input[@id='age']");
		public static By salary = By.XPath("//div[@class='modal-content']//input[@id='salary']");
		public static By departament = By.XPath("//div[@class='modal-content']//input[@id='department']");
		public static By submit = By.XPath("//div[@class='modal-content']//button[@id='submit']");
		public static By ModalX = By.XPath("//button[@class='close']");


		public By LookUptext(string numberofcelda, string text)
		{
			return By.XPath($"//div[@class='rt-tr-group']//div[@class='rt-td'][{numberofcelda}][(text()='{text}')]");
			////div[@class='rt-tr-group']//div[@class='rt-td'][1][normalize-space(text())='Kierra']
		}
	}
}

