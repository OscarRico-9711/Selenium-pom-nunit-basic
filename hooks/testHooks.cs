using OpenQA.Selenium;
using Practica_selenium___nunit___pom_basic.drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.hooks
{
	public class testHooks
	{
		
		[SetUp]
		public void setUp()
		{

			webDriverManager.getDriver();
		}

		[TearDown] 		
		public void tearDown()
		{
			Thread.Sleep(2000);
			webDriverManager.Quitdriver();		
		}
	}


}
