﻿using Allure.NUnit.Attributes;
using Allure.NUnit;
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
	[AllureFeature("Button Component")]
	[AllureSuite("Buttons")]
	public class TestButtons : testHooks
	{
		private HomePage _homepage;
		private ElementsPage _elements;
		private ButtonsPage _buttonsPage;

		[SetUp]
		public void Setup()
		{
			_homepage = new HomePage(driver);
			_elements = new ElementsPage(driver);
			_buttonsPage = new ButtonsPage(driver);
		}


		[Test]
		public void ValidateDoubleClick()
		{
			_homepage.OpenURL(ConfigHelper.Url);
			_homepage.SelectModule("Elements");
			_elements.SelectSubModule("Buttons");
			_buttonsPage.DoubleClick();
			_commonActions.TakeScreenshoot();
			_buttonsPage.RigthClick();
			_commonActions.TakeScreenshoot();
			_buttonsPage.RegularClick();
			_commonActions.TakeScreenshoot();

			string message = _buttonsPage.validateTextResultDoubleClick();
			Assert.That(message, Does.Contain("You have done a double click"), "El mensaje no es el correcto");


			string messageRight = _buttonsPage.validateTextResultRigthClick();
			Assert.That(messageRight, Does.Contain("You have done a right click"), "El mensaje no es el correcto");


			string messageClick = _buttonsPage.validateTextResultRegularClick();
			Assert.That(messageClick, Does.Contain("You have done a dynamic click"), "El mensaje no es el correcto");


		}


	}
}
