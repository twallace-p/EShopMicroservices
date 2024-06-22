var builder = WebApplication.CreateBuilder(args);

// Add servcies to the container

var app = builder.Build();

// Configure the Http request pipeline

app.Run();
