using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace NetCorePersianAnnotations
{
	public class PersianValidationMetadataProvider : IValidationMetadataProvider
	{
		private static readonly Dictionary<string, string> AllTranslations = new Dictionary<string, string>();

		static PersianValidationMetadataProvider()
		{
			PopulateAllTranslations();
		}

		public void CreateValidationMetadata(ValidationMetadataProviderContext context)
		{
			var attributes = context
				.PropertyAttributes
				?.OfType<ValidationAttribute>();

			if (attributes == null) return;

			foreach (var attribute in attributes)
			{
				TranslateAttributeError(attribute);
			}
		}


		private void TranslateAttributeError(ValidationAttribute attribute)
		{
			var errorMessageString = typeof(ValidationAttribute)
				.GetProperty("ErrorMessageString", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(attribute);

			if (errorMessageString == null)
			{
				return;
			}

			string error = errorMessageString.ToString();
			error = ToPersian(error);
			attribute.ErrorMessage = error;
		}

		public string ToPersian(string englishMessage)
		{
			bool tryTranslate = AllTranslations.TryGetValue(englishMessage, out var faMessage);

			if (tryTranslate)
			{
				return faMessage;
			}

			return englishMessage;
		}

		private static void PopulateAllTranslations()
		{
			var resourceProperties = typeof(DataAnnotationsResources)
				.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty);

			foreach (var property in resourceProperties)
			{
				string key = property.Name;
				string enValue = property.GetValue(null)?.ToString().Trim();
				string faValue = DataAnnotationsResourcesFa.ResourceManager.GetString(key)?.Trim();
				if (!string.IsNullOrEmpty(enValue) && !string.IsNullOrEmpty(faValue))
				{
					AllTranslations.Add(enValue, faValue);
				}
			}
		}
		
	}
}