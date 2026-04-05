using PangileCommerce.API.Middlewares;
using PangileCommerce.Core;
using PangileCommerce.Core.Mappers;
using PangileCommerce.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(
    options=> {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new ApplicationUserMappingProfile()));

//fluent validation
//builder.Services.AddFluentValidationAutoValidation();

//build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routes
app.MapControllers();

app.Run();
