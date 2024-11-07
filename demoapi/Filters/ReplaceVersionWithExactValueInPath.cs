using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

public class ApplyDocumentVersionFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var apiVersions = context.ApiDescriptions
            .Select(d => d.ActionDescriptor.GetApiVersion())
            .Distinct()
            .ToList();

        swaggerDoc.Paths = new OpenApiPaths();
        foreach (var apiVersion in apiVersions)
        {
            var paths = context.ApiDescriptions
                .Where(d => d.ActionDescriptor.GetApiVersion() == apiVersion)
                .Select(d => d.RelativePath)
                .Distinct()
                .ToList();

            foreach (var path in paths)
            {
                var apiDescription = context.ApiDescriptions
                    .FirstOrDefault(d => d.RelativePath == path && d.ActionDescriptor.GetApiVersion() == apiVersion);

                if (apiDescription != null)
                {
                    swaggerDoc.Paths.Add(path, new OpenApiPathItem
                    {
                        Operations =
                        {
                            [OperationType.Get] = new OpenApiOperation { Description = apiDescription.ActionDescriptor.DisplayName },
                            [OperationType.Post] = new OpenApiOperation { Description = apiDescription.ActionDescriptor.DisplayName },
                            [OperationType.Put] = new OpenApiOperation { Description = apiDescription.ActionDescriptor.DisplayName },
                            [OperationType.Delete] = new OpenApiOperation { Description = apiDescription.ActionDescriptor.DisplayName }
                        }
                    });
                }
            }
        }
    }
}

public static class ActionDescriptorExtensions
{
    public static ApiVersion GetApiVersion(this ActionDescriptor actionDescriptor)
    {
        var attribute = actionDescriptor.GetType().GetCustomAttributes(typeof(ApiVersionAttribute), true).FirstOrDefault();
        return ((ApiVersionAttribute)attribute).Versions.FirstOrDefault();
    }
}