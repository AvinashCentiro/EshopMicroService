using Carter;
using System.Reflection.Metadata;
using BuildingBlocks.Behaviors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to container

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    //So in here we basically add our validation behavior as a pipeline behavior into mediator.
    // We also register all validators from our assembly with this way.
    // By using this pipeline behavior we achieve the cleaner handler methods focused on the business logic.
});

builder.Services.AddValidatorsFromAssembly(assembly);


builder.Services.AddCarter();//Carter will handle api endpoint. 
//Carter will scan our project this will be found.
// Create product endpoint that inherits from the ICarterModule.

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

//If you look at the ad carton method, this is adding the necessary services for Carter into ASP.Net
//code dependency injection.






var app = builder.Build();

//set up HTTP request pipeline
app.MapCarter();

//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-9.0#exception-handler-lambda
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        if (exception == null)
            return;
        
        var problemDetails = new ProblemDetails
        {
            Title = exception?.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception?.StackTrace
        };
       

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception,exception?.Message);

        // using static System.Net.Mime.MediaTypeNames;
        context.Response.StatusCode=StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json"; //Text.Plain;

        await context.Response.WriteAsJsonAsync(problemDetails);

        /*
        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
        {
            await context.Response.WriteAsync(" The file was not found.");
        }

        if (exceptionHandlerPathFeature?.Path == "/")
        {
            await context.Response.WriteAsync(" Page: Home.");
        }*/
    });
});

app.UseHsts();

//MapCarter maps the routes defined in the I Carter module implementation.
//Looking for the ICarter module implementation and map the required Http methods.
app.Run();

//Marten is a object relational mapping library.And this will use the PostgreSQL Json capabilities.
//And Marten is a powerful library that transform the PostgreSQL into dotnet transactional document database.
//It combines the flexibility of a document database with the reliability of the relational databases
//and catalog microservices using Marten for PostgreSQL interaction as a document database.