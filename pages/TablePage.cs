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

		public bool ModalIsNotPresent()
		{
			return ElementIsNotVisible(TablePageLocators.Modal);
		}


		public void FillName(string text)
		{
			SendText(TablePageLocators.name, text);
		}

		public bool ValidateNameField()
		{
			string atributerequired = getElementattribute("required", TablePageLocators.name);

			return atributerequired != null;
		}
		public void FillLast(string text)
		{
			SendText(TablePageLocators.last, text);
		}
		public void FillEmail(string text)
		{
			SendText(TablePageLocators.email, text);
		}

		public bool ValidateEmailRequired()
		{
			string atributerequired = getElementattribute("required", TablePageLocators.email);
			return atributerequired != null;	

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

		public void DeleteRecord(string name, string apellido)
		{
			Click(TablePageLocators.DeleteIcon(name, apellido));
		}

		public void DeleteALLRecord()
		{
			while (true)
			{
				var deleteButtons = _driver.FindElements(TablePageLocators.DeleteAllRecords);

				if (deleteButtons.Count == 0)
					break; // No hay más elementos, salir del loop

				deleteButtons[0].Click(); // Siempre eliminar el primer botón
			}
		}

		public void EditRecord(string name, string apellido)
		{
			Click(TablePageLocators.EditIcon(name, apellido));
		}

		public bool RecordNotExist(string v1, string v2)
		{
			return ElementIsNotVisible(TablePageLocators.DeleteIcon(v1, v2));
		}


		public bool RecordExist(string v1, string v2)
		{
			return ElementIsVisible(TablePageLocators.DeleteIcon(v1, v2));
		}
	}
}
