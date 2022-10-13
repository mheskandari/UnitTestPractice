using CarAgency.Repositories;
using CarAgency.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICarsAPI, CarsAPI>();
builder.Services.AddScoped<ICarDatabase, CarDatabase>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
