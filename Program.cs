using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options => {
    options.AddPolicy(
        "Production",
        policy => policy
            .WithOrigins("localhost")
            .WithMethods(["GET", "OPTIONS", "PATCH", "DELETE", "POST"])
    );

    options.AddPolicy(
        "Development",
        policy => policy
            .AllowAnyOrigin()
            .WithMethods(["GET", "OPTIONS", "PATCH", "DELETE", "POST"])
    );
});

builder.Configuration.AddEnvironmentVariables();

Env.Load();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
    app.UseHttpsRedirection();
}


app.MapGet("/api/v1/health", () => "ok");

app.MapControllers();

app.Run();
