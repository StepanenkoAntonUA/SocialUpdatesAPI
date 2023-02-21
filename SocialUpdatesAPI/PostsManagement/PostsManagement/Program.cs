using DataAccess;
using Domain;
using Domain.Services;
using Eventer.Events;
using System.Collections.Generic;

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

    var eventBus = new MemoEventBus();
    var handler = new IntegrationEventHandler();
    
    eventBus.Subscribe(typeof(SocialUpdatesAdded).FullName, handler);


}