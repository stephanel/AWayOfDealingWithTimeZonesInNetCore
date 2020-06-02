using DealingWithTimezonesInMvcCore.Infrastructure.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DealingWithTimezonesInMvcCore.Infrastructure.Extensions
{
    public static class DateTimeConverterExtensions
    {
        public static JsonOptions RegisterDateTimeConverter(this JsonOptions options, IServiceCollection services)
        {
            options.JsonSerializerOptions.Converters.Add(
                new DateTimeConverter(() => services.BuildServiceProvider().GetService<UserCultureInfo>())
            );
            return options;
        }
    }
}
