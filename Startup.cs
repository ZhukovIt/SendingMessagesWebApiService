using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SendingMessagesService.Logic;
using SendingMessagesService.Utils;

namespace SendingMessagesService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MessagesQueue>();
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => 
                    await context.Response.WriteAsync($"Server is launch! Start UTC time {DateTimeOffset.UtcNow.ToString("dd.MM.yyyy HH:mm:ss")}"));
                endpoints.MapControllers();
            });
        }
    }
}
