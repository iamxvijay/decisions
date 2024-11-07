using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add API versioning with URL segment reader
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // Set URL segment reader explicitly for version detection from URL
    options.ApiVersionReader = new Microsoft.AspNetCore.Mvc.Versioning.UrlSegmentApiVersionReader();
});



// Configure Swagger for API versioning with conflict resolution
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "Demo API", Version = "v2" });
    options.SwaggerDoc("v3", new OpenApiInfo { Title = "Demo API", Version = "v3" });

    // Resolve conflicting actions by selecting unique route descriptions
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Demo API V2");
        options.SwaggerEndpoint("/swagger/v3/swagger.json", "Demo API V3");
    });
}

// Exception handling middleware for detailed error logging
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An error occurred processing your request. Check server logs for details.");
    });
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
