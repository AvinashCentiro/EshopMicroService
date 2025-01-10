
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to container

var assembly = typeof(Program).Assembly;

#region AboutAllRegisteredLibraries
//for logging and exception handling video NO 90,91,92,93 pls check
//So in here we basically add our validation behavior as a pipeline behavior into mediator.
// We also register all validators from our assembly with this way.
// By using this pipeline behavior we achieve the cleaner handler methods focused on the business logic.

//Carter will handle api endpoint. 
//Carter will scan our project this will be found.
// Create product endpoint that inherits from the ICarterModule.

//If you look at the adcarton method, this is adding the necessary services for Carter into ASP.Net
//code dependency injection.

//MapCarter maps the routes defined in the I Carter module implementation.
//Looking for the ICarter module implementation and map the required Http methods.
//Marten is a object relational mapping library.And this will use the PostgreSQL Json capabilities.
//And Marten is a powerful library that transform the PostgreSQL into dotnet transactional document database.
//It combines the flexibility of a document database with the reliability of the relational databases
//and catalog microservices using Marten for PostgreSQL interaction as a document database.
#endregion

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));

});

builder.Services.AddValidatorsFromAssembly(assembly);


builder.Services.AddCarter();

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

//set up HTTP request pipeline
app.MapCarter();
app.UseExceptionHandler(option => { });//empty option parameter indicates that we are relying on custom configured handler.
app.Run();


