﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.locators
{
	public  class RadioButtonPageLocators
	{
		public static By CheckElement = By.CssSelector("label[for='yesRadio']");//para hacer click				

		public static By SuccessMesage = By.XPath("//span[@class='text-success']"); 
	}
}
