using DealingWithTimezonesInMvcCore.Infrastructure.Binders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DealingWithTimezonesInMvcCore.Infrastructure.Extensions
{
    public static class DateTimeBinderProviderExtension
    {
        public static MvcOptions RegisterDateTimeProvider(this MvcOptions options, IServiceCollection services)
        {
            if(options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.ModelBinderProviders.Insert(0, new DateTimeBinderProvider(
                () => services.BuildServiceProvider().GetService<UserCultureInfo>()
            ));

            return options;
        }
    }
}
