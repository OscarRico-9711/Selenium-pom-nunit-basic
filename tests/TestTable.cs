using Allure.NUnit;
using Allure.NUnit.Attributes;
using Practica_selenium___nunit___pom_basic.Config;
using Practica_selenium___nunit___pom_basic.hooks;
using Practica_selenium___nunit___pom_basic.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.tests
{
	[TestFixture]
	[AllureNUnit]
	[AllureFeature("Table component")]
	[AllureSuite("Table")]
	

	public class TestTable : testHooks
	{
		private HomePage _homepage;
		private ElementsPage _elements;
		private TablePage _tablePage;

		[SetUp]
		public void Setup()
		{
			_homepage = new HomePage(driver);
			_elements = new ElementsPage(driver);
			_tablePage = new TablePage(driver);
		}

		[Test]
		public void AddRecord()
		{
			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");
			_tablePage.SelectAddButton();

			bool modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);

			_tablePage.FillName("Oscar");
			_tablePage.FillLast("Rico");
			_tablePage.FillEmail("oscar@test.com");
			_tablePage.FillAge("27");
			_tablePage.FillSalary("3000");
			_tablePage.FillDepartamet("Cun");
			_tablePage.SubmitForm();

			bool modalNotvisible = _tablePage.ModalIsNotPresent();
			Assert.That(modalNotvisible, Is.True, "El modal SI es visible ");

			bool recordExist = _tablePage.RecordExist("Oscar", "Rico");
			Assert.That(recordExist, Is.True, "El registro no fue editado");

		}
		[Test]
		public void EditRecord()
		{

			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");
			_tablePage.SelectAddButton();
			bool modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);

			_tablePage.FillName("Oscar");
			_tablePage.FillLast("Rico");
			_tablePage.FillEmail("oscar@test.com");
			_tablePage.FillAge("27");
			_tablePage.FillSalary("3000");
			_tablePage.FillDepartamet("Cun");
			_tablePage.SubmitForm();


			bool modalNotvisible = _tablePage.ModalIsNotPresent();
			Assert.That(modalNotvisible, Is.True, "esta visible el modal");

			_tablePage.EditRecord("Oscar", "Rico");

			modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);

			_tablePage.FillName("Daniel");
			_tablePage.SubmitForm();

			modalNotvisible = _tablePage.ModalIsNotPresent();
			Assert.That(modalNotvisible, Is.True, "El modal SI es visible ");

			bool recordExist = _tablePage.RecordExist("Daniel", "Rico");
			Assert.That(recordExist, Is.True, "El registro no fue editado");
		}

		[Test]
		public void DeleteRecord()
		{
			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");
			_tablePage.SelectAddButton();

			bool modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);

			_tablePage.FillName("Oscar");
			_tablePage.FillLast("Rico");
			_tablePage.FillEmail("oscar@test.com");
			_tablePage.FillAge("27");
			_tablePage.FillSalary("3000");
			_tablePage.FillDepartamet("Cun");
			_tablePage.SubmitForm();


			bool modalNotvisible = _tablePage.ModalIsNotPresent();
			Assert.That(modalNotvisible, Is.True, "esta visible el modal");

			_tablePage.DeleteRecord("Oscar", "Rico");

			bool recordnOTExist = _tablePage.RecordNotExist("Oscar", "Rico");
			Assert.That(recordnOTExist, Is.True, "El registro no fue eliminado");
		}

		[Test]
		public void CLoseModal()
		{
			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");
			_tablePage.SelectAddButton();

			bool modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);

			_tablePage.CloseModal();

			bool modalNotvisible = _tablePage.ModalIsPresent();
			Assert.That(modalNotvisible, Is.True);

		}

		[Test]
		public void DeleteAllRecords()
		{
			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");

			_tablePage.DeleteALLRecord();

			Thread.Sleep(4000);
		} 


		[Test]
		public void ValidateFields()
		{

			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");
			_tablePage.SelectAddButton();

			bool modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);


			bool isrequired = _tablePage.ValidateNameField();
			Assert.That(isrequired, Is.True);


			bool isrequiredEmail = _tablePage.ValidateEmailRequired();
			Assert.That(isrequiredEmail, Is.True);
		}
	}
}
