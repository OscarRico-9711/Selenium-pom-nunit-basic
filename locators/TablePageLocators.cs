using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.locators
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



		public static By DeleteIcon(string name, string apellido)
		{

			return By.XPath($"//div[@class='rt-tr -even'][div[contains(text(),'{name}')]][div[contains(text(),'{apellido}')]]//span[@title='Delete']");
			////div[@class='rt-tr -even'][div[contains(text(),'Oscar')]][div[contains(text(),'Rico')]]//span[@title='Delete']
			//div[contains(@class,'rt-tr')][.//div[contains(text(),'Oscar')]][.//div[contains(text(),'Rico')]]//span[@title='Delete']
		}

		public static By DeleteAllRecords = By.XPath("//span[@title='Delete']");

		public static By EditIcon(string name, string apellido)
		{

			return By.XPath($"//div[@class='rt-tr -even'][div[contains(text(),'{name}')]][div[contains(text(),'{apellido}')]]//span[@title='Edit']");
		}

		public By Particularrecord(string name, string apellido)
		{
			return By.XPath($".//div[contains(text(),'{name}')][//div[contains(text(),'{apellido}')]]");
		}
	}
}

