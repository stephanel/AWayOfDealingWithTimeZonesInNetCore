using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace DealingWithTimezonesInMvcCore.Infrastructure.Binders
{
    public class DateTimeBinder : IModelBinder
    {
        private readonly UserCultureInfo _userCulture;

        public DateTimeBinder(UserCultureInfo userCulture)
        {
            _userCulture = userCulture;
        }

        public Task BindModelAsync(ModelBindingContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var valueProviderResult = context.ValueProvider.GetValue(context.ModelName);

            if(string.IsNullOrWhiteSpace(valueProviderResult.FirstValue))
            {
                return null;
            }

            DateTime datetime;
            if(DateTime.TryParse(valueProviderResult.FirstValue, null, DateTimeStyles.AdjustToUniversal, out datetime))
            {
                context.Result = ModelBindingResult.Success(_userCulture.GetUtcTime(datetime));
            }       
            else
            {
                context.ModelState.TryAddModelError(
                    context.ModelName,
                    context.ModelMetadata
                        .ModelBindingMessageProvider
                        .AttemptedValueIsInvalidAccessor(valueProviderResult.ToString(), nameof(DateTime)));
            }

            return Task.CompletedTask;
        }
    }
}
