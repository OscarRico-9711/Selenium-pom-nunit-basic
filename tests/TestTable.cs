using Practica_selenium___nunit___pom_basic.hooks;
using Practica_selenium___nunit___pom_basic.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.tests
{
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
			_homepage.OpenURL("https://demoqa.com/");
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

			bool modalNotvisible = _tablePage.ModalIsPresent();
			Assert.That(modalNotvisible, Is.True);

		}

		[Test]
		public void CLoseModal()
		{
			_homepage.OpenURL("https://demoqa.com/");
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Web Tables");
			_tablePage.SelectAddButton();

			bool modalvisible = _tablePage.ModalIsPresent();
			Assert.That(modalvisible, Is.True);

			_tablePage.CloseModal();

			bool modalNotvisible = _tablePage.ModalIsPresent();
			Assert.That(modalNotvisible, Is.True);

		}
	}
}
