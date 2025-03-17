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
	public class TestGoogle : testHooks
	{


		/// <summary>
		/// fill full form succesfuly
		/// </summary>
		[Test]
		public void FillFullFormSuccesfully()
		{
			_homePage.OpenURL("https://demoqa.com");
			_homePage.SelectElemetsModule();

			string currentUrl = _elementPages.GetCurrentUrl();
			Assert.That(currentUrl, Is.EqualTo("https://demoqa.com/elements"), "Url incorrecta");

			_elementPages.SelectTextBoxOption();

			string fullname = "Oscar";
			string fullEmail = "Oscar@gmail.com";
			string fullCurrentAdress = "calle23";

			_elementPages.FillFullForm(fullname, fullEmail, fullCurrentAdress);


			bool IsOutputVisible = _elementPages.ElementIsVisible();
			Assert.That(IsOutputVisible, Is.True, "Elemento no esta presente");

			string fullnameOutPut = _elementPages.GetOutputTextName();
			string fullEmaiOutPut = _elementPages.GetOutputTextEmail();
			string fullCurrentAdressOutPut = _elementPages.GetOutputTextAddress();

			Assert.That(fullnameOutPut, Does.Contain(fullname));
			Assert.That(fullEmaiOutPut, Does.Contain(fullEmail));
			Assert.That(fullCurrentAdressOutPut, Does.Contain(fullCurrentAdress));
		}

		[Test]
		public void ValidateEmailFieldError()
		{

			_homePage.OpenURL("https://demoqa.com");
			_homePage.SelectElemetsModule();

			string currentUrl = _elementPages.GetCurrentUrl();
			Assert.That(currentUrl, Is.EqualTo("https://demoqa.com/elements"), "Url incorrecta");

			_elementPages.SelectTextBoxOption();

			string fullname = "Oscar";
			string fullEmail = "Oscargmail.com";
			string fullCurrentAdress = "calle23";

			_elementPages.FillFullForm(fullname, fullEmail, fullCurrentAdress);

			bool IsOutputNotVisible = _elementPages.ElementIsNotVisible();
			Assert.That(IsOutputNotVisible, Is.True, "Elemento si esta presente");

			string emailatribute = _elementPages.GetEmailFieldAtribute().ToLower();
			Assert.That(emailatribute, Does.Contain("error"));

		}
	}

}