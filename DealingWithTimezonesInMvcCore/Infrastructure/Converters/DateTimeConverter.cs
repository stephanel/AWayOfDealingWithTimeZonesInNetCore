using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DealingWithTimezonesInMvcCore.Infrastructure.Converters
{
    /// <summary>  
    /// JSON Date time converter.  
    /// </summary>  
    /// <seealso cref="DateTimeConverterBase" /> 
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly Func<UserCultureInfo> _getUserCulture;

        public DateTimeConverter(Func<UserCultureInfo> getUserCulture)
        {
            _getUserCulture = getUserCulture;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>  
        /// Writes the JSON representation of the object.  
        /// </summary>  
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>  
        /// <param name="value">The value.</param>  
        /// <param name="serializer">The calling serializer.</param>  
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // null are already filtered
            var userCulture = _getUserCulture();

            writer.WriteStringValue(TimeZoneInfo.ConvertTime(Convert.ToDateTime(value), userCulture.TimeZone)
                .ToString(userCulture.DateTimeFormat));
            writer.Flush();
        }
    }
}
