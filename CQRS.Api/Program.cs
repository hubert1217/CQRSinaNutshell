using CQRS.Api;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApplication();

var app = builder.Build();

app.Configure();

app.Run();
