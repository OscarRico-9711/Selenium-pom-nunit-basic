using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_selenium___nunit___pom_basic.Config
{
	/// <summary>
	/// Get the Json atributes from AppSettings.json 
	/// </summary>
	public static class ConfigHelper
	{


		private static readonly IConfigurationRoot config;

		static ConfigHelper()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)  // Ruta base dinámica
				.AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true); // Carga el JSON

			config = builder.Build();
		}



		public static string Browser => config["Browser"]?.ToString() ?? "chrome";
		public static bool IsHeadless => bool.TryParse(config["HideBrowser"], out var result) && result;
		public static string Url => config["Url"]?.ToString() ?? "https://demoqa.com";

	}
}
