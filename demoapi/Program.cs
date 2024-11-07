using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "testuser",
            ValidAudience = "password123",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("auwiJCieIRrP4h2fv2TZLWEwka260LOA")) // Consistent encoding
        };
    });



// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

// Configure Swagger for API versioning
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API v1", Version = "v1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "Demo API v2", Version = "v2" });
    options.SwaggerDoc("v3", new OpenApiInfo { Title = "Demo API v3", Version = "v3" });
    options.SwaggerDoc("v4", new OpenApiInfo { Title = "Demo API v4 Auth", Version = "v4" });

    // Configure JWT Bearer authentication for Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // This will automatically add 'Bearer ' prefix
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    options.DocInclusionPredicate((documentName, apiDescription) =>
    {
        var versions = apiDescription.ActionDescriptor.EndpointMetadata
                                      .OfType<ApiVersionAttribute>()
                                      .SelectMany(attr => attr.Versions);
        return versions.Any(v => $"v{v.MajorVersion}" == documentName);
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API v1 - db1 - uses mock data");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Demo API v2 - db1 - same db custom results");
        options.SwaggerEndpoint("/swagger/v3/swagger.json", "Demo API v3 - db2 - v2 with differnt db");
        options.SwaggerEndpoint("/swagger/v4/swagger.json", "Demo API v4 - db2 - v3 with  (Auth)");
    });
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
