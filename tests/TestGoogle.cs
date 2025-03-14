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

		private GooglePage googlePage;

		[SetUp]
		public void SetUp() {
			googlePage = new GooglePage(webDriverManager.getDriver());
		}

		[Test]
		public void SearchOnGoggle()
		{
			googlePage.OpenUrl();
			googlePage.SelectContact();
			
		}


	}
}
