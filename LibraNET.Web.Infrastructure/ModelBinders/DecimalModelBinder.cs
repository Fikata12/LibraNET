using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace LibraNET.Web.Infrastructure.ModelBinders
{
	public class DecimalModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext? bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

			if (result != ValueProviderResult.None && !string.IsNullOrWhiteSpace(result.FirstValue))
			{
				decimal parsedValue = 0m;
				bool binderSucceeded = false;

				try
				{
					string formDecValue = result.FirstValue;

					formDecValue = formDecValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					formDecValue = formDecValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					parsedValue = Convert.ToDecimal(formDecValue);
					binderSucceeded = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}

				if (binderSucceeded)
				{
					bindingContext.Result = ModelBindingResult.Success(parsedValue);
				}
			}

			return Task.CompletedTask;
		}
	}
}
