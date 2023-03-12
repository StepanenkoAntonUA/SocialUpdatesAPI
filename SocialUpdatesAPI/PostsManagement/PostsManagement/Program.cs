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

ConfigureServices(builder.Services);
builder.Services.AddControllers();

// есть метод ConfigureServices ниже. ј почему тогда эти инициализации наход€тс€ десь?
// еще лучше - сделать ConfigureStores и вынести это туда. ¬ызывать перед ConfigureServices, т.к. по уровн€м Stoe соит ниже Service и Service нужны готовые Store дл€ работы
builder.Services.AddSingleton<IPostsStore, PostsStore>();
builder.Services.AddSingleton<ISocialGroupStore, SocialGroupStore>();
builder.Services.AddTransient<IPostsDao, PostsDao>();




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
    
    services.AddHostedService<PlannedPostsChecker>();

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