using DataAccess.Stores;
using Domain;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);
builder.Services.AddControllers();
builder.Services.AddSingleton<IUpdateStore, UpdateStore>();
builder.Services.AddSingleton<ISocialGroupStore, SocialGroupStore>();
builder.Services.AddTransient<ISocialUpdatesStore, SocialUpdatesStore>();


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

}