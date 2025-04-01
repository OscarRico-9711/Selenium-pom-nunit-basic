using Allure.NUnit;
using Allure.NUnit.Attributes;
using Practica_selenium___nunit___pom_basic.drivers;
using Practica_selenium___nunit___pom_basic.hooks;
using Practica_selenium___nunit___pom_basic.pages;
using Practica_selenium___nunit___pom_basic.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.tests
{
	[TestFixture]
	[AllureNUnit]
	[AllureFeature("form component")]
	[AllureSuite("Form")]

	public class TestGoogle : testHooks
	{
		private HomePage _homePage;
		private ElementsPage _elementsPage;


		[SetUp]
		public void SetUp() {

			_homePage = new HomePage(driver);
			_elementsPage = new ElementsPage(driver);
		}

		/// <summary>
		/// fill full form succesfuly
		/// </summary>
		[Test]
		public void FillFullFormSuccesfully()
		{
			_homePage.OpenURL("https://demoqa.com");
			_homePage.SelectModule("Elements");

			string currentUrl = _elementsPage.GetCurrentUrl();
			Assert.That(currentUrl, Is.EqualTo("https://demoqa.com/elements"), "Url incorrecta");

			_elementsPage.SelectSubModule("Text Box");

			string fullname = "Oscar";
			string fullEmail = "Oscar@gmail.com";
			string fullCurrentAdress = "calle23";

			_elementsPage.FillFullForm(fullname, fullEmail, fullCurrentAdress);


			bool IsOutputVisible = _elementsPage.ElementIsVisible();
			Assert.That(IsOutputVisible, Is.True, "Elemento no esta presente");

			string fullnameOutPut = _elementsPage.GetOutputTextName();
			string fullEmaiOutPut = _elementsPage.GetOutputTextEmail();
			string fullCurrentAdressOutPut = _elementsPage.GetOutputTextAddress();

			Assert.That(fullnameOutPut, Does.Contain(fullname));
			Assert.That(fullEmaiOutPut, Does.Contain(fullEmail));
			Assert.That(fullCurrentAdressOutPut, Does.Contain(fullCurrentAdress));
		}

		[Test]
		public void ValidateEmailFieldError()
		{

			_homePage.OpenURL("https://demoqa.com");
			_homePage.SelectModule("Elements");

			string currentUrl = _elementsPage.GetCurrentUrl();
			Assert.That(currentUrl, Is.EqualTo("https://demoqa.com/elements"), "Url incorrecta");

			_elementsPage.SelectSubModule("Text Box");

			string fullname = "Oscar";
			string fullEmail = "Oscargmail.com";
			string fullCurrentAdress = "calle23";

			_elementsPage.FillFullForm(fullname, fullEmail, fullCurrentAdress);

			bool IsOutputNotVisible = _elementsPage.ElementIsNotVisible();
			Assert.That(IsOutputNotVisible, Is.True, "Elemento si esta presente");

			string emailatribute = _elementsPage.GetEmailFieldAtribute().ToLower();
			Assert.That(emailatribute, Does.Contain("error"));

		}
	}

}