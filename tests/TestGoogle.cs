using Practica_selenium___nunit___pom_basic.drivers;
using Practica_selenium___nunit___pom_basic.hooks;
using Practica_selenium___nunit___pom_basic.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.tests
{
	public class TestGoogle : testHooks
	{

		private HomePage _homePage;

		[SetUp]
		public void SetUp()
		{
			_homePage = new HomePage(webDriverManager.getDriver("chrome"));
		}

		[Test]
		public void FillFullFormSuccesfully()
		{
			_homePage.OpenURL("https://demoqa.com");
			_homePage.SelectElemetsModule();

			string currentUrl = _homePage.GetCurrentUrl();
			Assert.That(currentUrl, Is.EqualTo("https://demoqa.com/elements"), "Url incorrecta");

			_homePage.SelectTextBoxOption();
			_homePage.FillFullForm("Oscar", "Oscar@gmail.com", "calle23");


			bool IsOutputVisible = _homePage.ElementIsVisible();
			Assert.That(IsOutputVisible, Is.True, "Elemento no esta presente");

			///validar data agregada que sea la misma en el output

		}


	}

}
