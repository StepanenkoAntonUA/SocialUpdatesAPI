using PostsManagement.Service;
using PostsManagement.Store;


var builder = WebApplication.CreateBuilder(args);


ConfigureServices(builder.Services);
builder.Services.AddControllers();
builder.Services.AddSingleton<IPostsManagementStore, PostsManagementStore>();



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



}