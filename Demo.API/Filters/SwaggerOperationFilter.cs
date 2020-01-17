using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Demo.API.Filters
{
    public class SwaggerOperationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizationRequired = context.ApiDescription.CustomAttributes().Any(a => a is AuthorizeAttribute);

            if (authorizationRequired)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field.",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Default = new OpenApiString("Bearer ")
                    }
                });
            }
        }
    }
}
