using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

builder.Services.AddControllers();
builder.Services.AddScoped<IUpdateStore, UpdateStore>();
builder.Services.AddDbContext<SocialUpdatesContext>(opt =>
    opt.UseInMemoryDatabase("SocialUpdates"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
