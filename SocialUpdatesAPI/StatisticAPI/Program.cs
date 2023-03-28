using Common;
using Common.Configuration;
using DataAccess.DAOs;
using DataAccess.Stores;
using Domain;
using Domain.Services;
using System.Configuration;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfigurationBuilder();
IConfiguration configuration = config.Build();

ConfigureServices(builder.Services);
ConfigureStores(builder.Services);
builder.Services.AddControllers();

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
    services.AddTransient<ISocialUpdatesService, SocialUpdatesService>();
    services.AddTransient<ISocialGroupService, SocialGroupService>();
    services.AddTransient<IPlannedPostService, PlannedPostService>();
    services.AddTransient<IStatisticService, StatisticService>();

    var options = configuration.GetSection(PlannedPostsCheckerOptions.SectionName);
    services.Configure<PlannedPostsCheckerOptions>(options);


}

void ConfigureStores(IServiceCollection services)
{

    var connectionStringDescriptor = new ConnectionStringDescriptor
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection")

    };

    services.AddTransient<ISocialUpdatesStore, SocialUpdatesStore>();
    services.AddTransient<ISocialUpdatesDao>(descriptor => new SocialUpdatesDao(connectionStringDescriptor));

    builder.Services.AddSingleton<IUpdateStore, UpdateStore>();
    builder.Services.AddSingleton<ISocialGroupStore, SocialGroupStore>();
    builder.Services.AddTransient<IPlannedPostStore, PlannedPostStore>();


}
