var builder = WebApplication.CreateBuilder(args);

// Add services to container

var app = builder.Build();

//set up HTTP request pipeline

app.Run();