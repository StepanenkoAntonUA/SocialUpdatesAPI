using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NuGet.Packaging.Signing;
using SocialUpdatesAPI.Service;
using SocialUpdatesAPI.Store;
using System;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);


ConfigureServices(builder.Services);
builder.Services.AddControllers();
builder.Services.AddSingleton<IUpdateStore, UpdateStore>();


builder.Services.AddCors(p =>
{
    p.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

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


void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<SocialUpdatesService>();
    

}