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
	public class TablePage : CommonActions
	{

		public TablePage(IWebDriver driver) : base(driver) { }


		public void SelectAddButton()
		{
			Click(TablePageLocators.AddButton);
		}

		public bool ModalIsPresent()
		{
			return ElementIsVisible(TablePageLocators.Modal);
		}

	
		public void FillName(string text)
		{
			SendText(TablePageLocators.name, text);
		}
		public void FillLast(string text)
		{
			SendText(TablePageLocators.last, text);
		}
		public void FillEmail(string text)
		{
			SendText(TablePageLocators.email, text);
		}
		public void FillAge(string text)
		{
			SendText(TablePageLocators.age, text);
		}
		public void FillSalary(string text)
		{
			SendText(TablePageLocators.salary, text);
		}
		public void FillDepartamet(string text)
		{
			SendText(TablePageLocators.departament, text);
		}
		public void SubmitForm()
		{
			Click(TablePageLocators.submit);
			
		}

		public void CloseModal()
		{
			Click(TablePageLocators.ModalX);			
		}

	}
}
