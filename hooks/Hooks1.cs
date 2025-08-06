using OpenQA.Selenium;
using PracticaNunitAllureJenkins1.drivers;
using Reqnroll;
using Reqnroll.BoDi;

namespace PracticaNunitAllureJenkins1.Hooks
{
	[Binding]
	public sealed class Hooks1
	{
		private readonly IObjectContainer _objectContainer;
		private webDriverManager _webDriverManager;

		public Hooks1(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			_webDriverManager = new webDriverManager();
			var driver = _webDriverManager.getDriver();
			_objectContainer.RegisterInstanceAs<IWebDriver>(driver);
		}

		[AfterScenario]
		public void AfterScenario()
		{
			_webDriverManager.QuitDriver();
		}
	}
}
