using Common;
using Common.Configuration;
using DataAccess.DAOs;
using DataAccess.Stores;
using Domain;
using Domain.Services;
using Eventer.Common;
using Eventer.Events;
using Eventer.Events.Events;
using Eventer.Events.Handlers;
using PostsManagementAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfigurationBuilder();
IConfiguration configuration = config.Build();


ConfigureStores(builder.Services);
ConfigureServices(builder.Services);
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
    services.AddTransient<IPostsManagementService, PostsManagementService>();
    services.AddTransient<ISocialGroupService, SocialGroupService>();
    services.AddTransient<ISerializer, Serializer>();

    // PlannedPostsCheckerDescriptor переименовать в PlannedPostsCheckerOptions. Это Options а не "описание"
    var checkerDescriptor = new PlannedPostsCheckerDescriptor
    {
        IntervalSec = int.Parse(configuration["UpdateIntervalSec"])
        // Int32 - не используем. Это для сохранения взаимозаменяемости C# с Visual Basic

        // давай переделаем конфигурацию под Configuration.GetSection(PositionOptions.Position).Get<PositionOptions>(); как в примере тут https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0 
        // и передавать IOptions в IDao
        // будет примерно Configuration.GetSection(PlannedPostsCheckerOptions.SectionName).Get<PlannedPostsCheckerOptions>()
    };

    services.AddHostedService<PlannedPostsChecker>(service => new PlannedPostsChecker(checkerDescriptor));

    services.AddTransient<IIntegrationEventHandler<SocialPostCommentedEvent>, SocialPostCommentedHandler>();
    services.AddTransient<IIntegrationEventHandler<SocialPostCreatedEvent>, SocialPostCreatedHandler>();
    services.AddTransient<IIntegrationEventHandler<SocialPostSentEvent>, SocialPostSentHandler>();

    var assemblyList = new List<Assembly>
    {
        typeof(SocialPostCommentedEvent).Assembly
    };

    services.AddSingleton<IEventBus>(provider =>
    {
        var instance = new MemoEventBus(provider);
        instance.Initialize(assemblyList);

        return instance;
    });
}

void ConfigureStores(IServiceCollection services)
{

    var connectionStringDescriptor = new ConnectionStringDescriptor
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection")
    };

    services.AddSingleton<IPostsStore, PostsStore>();
    services.AddSingleton<ISocialGroupStore, SocialGroupStore>();
    services.AddTransient<IPostsDao>(descriptor => new PostsDao(connectionStringDescriptor));
}