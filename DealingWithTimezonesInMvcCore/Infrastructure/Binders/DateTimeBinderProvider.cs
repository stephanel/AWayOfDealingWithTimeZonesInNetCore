using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace DealingWithTimezonesInMvcCore.Infrastructure.Binders
{
    /// <summary>  
    /// <see cref="DateTimeBinder"/> provider.  
    /// </summary>  
    /// <seealso cref="IModelBinderProvider" /> 
    public class DateTimeBinderProvider : IModelBinderProvider
    {
        private readonly Func<UserCultureInfo> _getUserCulture;

        public DateTimeBinderProvider(Func<UserCultureInfo> getUserCulture)
        {
            _getUserCulture = getUserCulture;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if(context.Metadata.UnderlyingOrModelType == typeof(DateTime))
            {
                return new DateTimeBinder(_getUserCulture());
            }

            return null;
        }
    }
}
