using Merchants.Web.Options;
using Microsoft.AspNetCore.Builder;
using System;

namespace Merchants.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerForMerchantApplication(this IApplicationBuilder app,
            Action<SwaggerOptions> optionsBuilder)
        {
            var swaggerOptions = new SwaggerOptions();
            optionsBuilder(swaggerOptions);

            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
        }
    }
}
