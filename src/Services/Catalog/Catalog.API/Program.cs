using Carter;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddCarter();//Carter will handle api endpoint. 
//Carter will scan our project this will be found.
// Create product endpoint that inherits from the ICarterModule.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
   
    
//If you look at the ad carton method, this is adding the necessary services for Carter into ASP.Net
//code dependency injection.

var app = builder.Build();

//set up HTTP request pipeline
app.MapCarter();
//MapCarter maps the routes defined in the I Carter module implementation.
//Looking for the ICarter module implementation and map the required Http methods.
app.Run();

//Marten is a object relational mapping library.And this will use the PostgreSQL Json capabilities.
//And Marten is a powerful library that transform the PostgreSQL into dotnet transactional document database.
//It combines the flexibility of a document database with the reliability of the relational databases
//and catalog microservices using Marten for PostgreSQL interaction as a document database.