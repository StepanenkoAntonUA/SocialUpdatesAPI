using SocialUpdatesAPI.Store;

namespace SocialUpdatesAPI
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IUpdateStore, UpdateStore>();
        }
    }
}
