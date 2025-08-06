using System;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using Reqnroll;
using PracticaNunitAllureJenkins1.Config;
using PracticaNunitAllureJenkins1.pages;
using OpenQA.Selenium;
using PracticaNunitAllureJenkins1.drivers;
using WebDriverManager;
using PracticaNunitAllureJenkins1.utilities;

namespace PracticaNunitAllureJenkins1.StepDefinitions
{
    [Binding]
	public class ButtonsStepDefinitions
    {
		private readonly HomePage _homepage;
		private readonly ElementsPage _elements;
		private readonly ButtonsPage _buttonsPage;
		private readonly CommonActions _commonActions;

		public ButtonsStepDefinitions(IWebDriver driver)
		{
			_homepage = new HomePage(driver);
			_elements = new ElementsPage(driver);
			_buttonsPage = new ButtonsPage(driver);
			_commonActions = new CommonActions(driver);
		}

		[Given("the user opens the application URL")]
		public void GivenTheUserOpensTheApplicationURL()
		{
			_homepage.OpenURL(ConfigHelper.Url);
		}

		[When("the user selects the {string} module")]
		public void WhenTheUserSelectsTheModule(string module)
		{
			_homepage.SelectModule(module);
		}

		[When("the user selects the {string} submodule")]
		public void WhenTheUserSelectsTheSubmodule(string submodule)
		{
			_elements.SelectSubModule(submodule);
		}

		[When("the user performs a double click on the button")]
		public void WhenTheUserPerformsADoubleClickOnTheButton()
		{
			_buttonsPage.DoubleClick();
			_commonActions.TakeScreenshoot();
		}

		[When("the user performs a right click on the button")]
		public void WhenTheUserPerformsARightClickOnTheButton()
		{
			_buttonsPage.RigthClick();
			_commonActions.TakeScreenshoot();
		}

		[When("the user performs a regular click on the button")]
		public void WhenTheUserPerformsARegularClickOnTheButton()
		{
			_buttonsPage.RegularClick();
			_commonActions.TakeScreenshoot();
		}

		[Then("the message {string} should be displayed")]
		public void ThenTheMessageShouldBeDisplayed(string expectedMessage)
		{
			// Validate all three messages
			string doubleClickMsg = _buttonsPage.validateTextResultDoubleClick();
			string rightClickMsg = _buttonsPage.validateTextResultRigthClick();
			string regularClickMsg = _buttonsPage.validateTextResultRegularClick();

			Assert.That(doubleClickMsg, Does.Contain("You have done a double click"), "El mensaje no es el correcto");
			Assert.That(rightClickMsg, Does.Contain("You have done a right click"), "El mensaje no es el correcto");
			Assert.That(regularClickMsg, Does.Contain("You have done a dynamic click"), "El mensaje no es el correcto");
		}

	}
}
