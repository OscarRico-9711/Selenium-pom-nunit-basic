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
		//instances
		private HomePage _homePage;
		private CommonActions _commonActions;

		[SetUp]
		public void SetUp()
		{
			var _driver = webDriverManager.getDriver("chrome");

			_homePage = new HomePage(_driver);
			_commonActions = new CommonActions(_driver);
		}


		/// <summary>
		/// fill full form succesfuly
		/// </summary>
		[Test]
		public void FillFullFormSuccesfully()
		{
			_homePage.OpenURL("https://demoqa.com");
			_homePage.SelectElemetsModule();

			string currentUrl = _homePage.GetCurrentUrl();
			Assert.That(currentUrl, Is.EqualTo("https://demoqa.com/elements"), "Url incorrecta");

			_homePage.SelectTextBoxOption();

			string fullname = "Oscar";
			string fullEmail = "Oscar@gmail.com";
			string fullCurrentAdress = "calle23";

			_homePage.FillFullForm(fullname, fullEmail, fullCurrentAdress);


			bool IsOutputVisible = _homePage.ElementIsVisible();
			Assert.That(IsOutputVisible, Is.True, "Elemento no esta presente");

			string fullnameOutPut = _homePage.GetOutputTextName();
			string fullEmaiOutPut = _homePage.GetOutputTextEmail();
			string fullCurrentAdressOutPut = _homePage.GetOutputTextAddress();

			Assert.That(fullnameOutPut, Does.Contain(fullname));
			Assert.That(fullEmaiOutPut, Does.Contain(fullEmail));
			Assert.That(fullCurrentAdressOutPut, Does.Contain(fullCurrentAdress));
		}
	}

}
