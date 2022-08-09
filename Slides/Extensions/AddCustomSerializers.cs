using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace BasicsForExperts.Web.Extensions
{

    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomSerializers(this IServiceCollection services)
        {
            services.AddSingleton(sp => new JsonSerializerOptions
            {
                Converters =
                {
                    new EnumConvertor<WaffleTypeEnum>()
                },
                ReferenceHandler = ReferenceHandler.IgnoreCycles

        });
           
            return services;
        }
    }
}

