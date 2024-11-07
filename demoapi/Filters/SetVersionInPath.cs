using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class SetVersionInPath : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var updatedPaths = new OpenApiPaths();

        foreach (var path in swaggerDoc.Paths)
        {
            // Replace "v{version}" with the actual Swagger document version
            var newPathKey = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
            updatedPaths.Add(newPathKey, path.Value);
        }

        swaggerDoc.Paths = updatedPaths;
    }
}
