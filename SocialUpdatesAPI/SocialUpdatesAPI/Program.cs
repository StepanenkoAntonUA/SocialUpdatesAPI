using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SocialUpdatesAPI.Models;
using SocialUpdatesAPI.Store;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
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


