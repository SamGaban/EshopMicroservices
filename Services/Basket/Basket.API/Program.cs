var builder = WebApplication.CreateBuilder(args);

// Retrieving the assembly
var assembly = typeof(Program).Assembly;

// DI

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});


var app = builder.Build();
// HTTP request pipeline

app.MapCarter();

app.Run();