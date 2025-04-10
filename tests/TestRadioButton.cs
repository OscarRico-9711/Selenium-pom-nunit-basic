using Allure.NUnit;
using Allure.NUnit.Attributes;
using PracticaNunitAllureJenkins1.Config;
using PracticaNunitAllureJenkins1.hooks;
using PracticaNunitAllureJenkins1.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNunitAllureJenkins1.tests
{
	[TestFixture]
	[AllureNUnit]
	[AllureFeature("Radio Button component")]
	[AllureSuite("Radio Button")]
	internal class TestRadioButton : testHooks
	{
		private HomePage _homePage;
		private ElementsPage _elementsPage;
		private RadioButtonPage _radioButtonPage;


		[SetUp]
		public void SetUp()
		{

			_homePage = new HomePage(driver);
			_elementsPage = new ElementsPage(driver);
			_radioButtonPage = new RadioButtonPage(driver);


		}


		[Test]
		[Retry(2)]
		public void ValidateSelectedRadioButton()
		{
		
			_homePage.OpenURL(ConfigHelper.Url);
			_homePage.SelectModule("Elements");
			_elementsPage.SelectSubModule("Radio Button");
			_radioButtonPage.selectRadioButton();
		
			string SucessText = _radioButtonPage.ValidateText();
			Assert.That(SucessText, Does.Contain("Yes"), "it's a different mesage");





		}

	}
}
