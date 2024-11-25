var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();
string[] cors = [];

builder.Services.AddCors(options => {
    options.AddPolicy("Production", policy => policy
        .WithOrigins("localhost")
        .WithMethods(["GET", "OPTIONS", "PATCH", "DELETE", "POST"])
        .AllowAnyMethod()
    );

    options.AddPolicy("Development", policy => policy
        .AllowAnyOrigin()
        .WithMethods(["GET", "OPTIONS", "PATCH", "DELETE", "POST"])
        .AllowAnyMethod()
);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");

}


app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowCredentials()
    .WithMethods(["GET", "OPTIONS", "PATCH", "DELETE", "POST"])
    .WithOrigins([""]));

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

app.Run();
