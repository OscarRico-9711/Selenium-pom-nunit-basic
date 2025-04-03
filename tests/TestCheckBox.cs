﻿using Allure.NUnit;
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
	[AllureFeature("Check box component")]
	[AllureSuite("check Box")]

	internal class TestCheckBox : testHooks
	{
		private HomePage _homePage;
		private ElementsPage _elementsPage;
		private CheckBoxPage _checkBoxPage;


		[SetUp]
		public void SetUp()
		{

			_checkBoxPage = new CheckBoxPage(driver);
			_homePage = new HomePage(driver);
			_elementsPage = new ElementsPage(driver);
		}

		[Test]
		public void ValidateIscheked()
		{

			_homePage.OpenURL(ConfigHelper.Url);
			_homePage.SelectModule("Elements");
			_elementsPage.SelectSubModule("Check Box");
			_checkBoxPage.SelectCheckBox();

			string classtext = _checkBoxPage.Validateischecked();
			Assert.That(classtext, Does.Contain("check"));

			string MessageSuccess = _checkBoxPage.validateMessage();
			Assert.That(MessageSuccess, Is.Not.Null.And.Not.Empty, "Element ono existe o es vacio");
			Assert.That(MessageSuccess, Does.Contain("selected "), "No contiene el texto sugerido");





		}
	}
}
