using System.Web.Http;
using WebActivatorEx;
using Northwind.Api;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Northwind.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
              .EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "Northwind");
                  c.PrettyPrint();
                  c.SchemaFilter<ApplyModelNameFilter>();
                  c.IncludeXmlComments(string.Format(@"{0}\bin\Northwind.Api.xml",
                                       System.AppDomain.CurrentDomain.BaseDirectory));

                  c.DescribeAllEnumsAsStrings();
              })
              .EnableSwaggerUi();
        }
    }

    class ApplyModelNameFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            schema.title = type.Name;
        }
    }
}
