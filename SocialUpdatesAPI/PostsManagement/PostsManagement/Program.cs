using DataAccess;
using Domain;
using Domain.Services;
using Eventer.Common;
using Eventer.Events;
using Eventer.Events.Events;
using Eventer.Events.Handlers;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);
builder.Services.AddControllers();
builder.Services.AddSingleton<IPostsStore, PostsStore>();
builder.Services.AddSingleton<ISocialGroupStore, SocialGroupStore>();



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

    var eventBus = new MemoEventBus();
    
    eventBus.Subscribe(typeof(SocialPostCommentedEvent), typeof(SocialPostCommentedHandler));
    eventBus.Subscribe(typeof(SocialPostCreatedEvent), typeof(SocialPostCreatedHandler));
    eventBus.Subscribe(typeof(SocialPostSentEvent), typeof(SocialPostSentHandler));

    services.AddSingleton<IEventBus>(eventBus);

}