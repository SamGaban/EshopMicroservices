var builder = WebApplication.CreateBuilder(args);

//Injections
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

//HTTP request pipeline
app.MapCarter();

app.Run();