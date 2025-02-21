using Programming_Test_Core.DependencyContainer;

namespace Programming_Test
{
    public class Startup
    {
        public readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void ConfigureService(IServiceCollection Services)
        {
            Services.AddControllers();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            RegisterServices(Services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization(); 

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("{\"error\": \"Ruta no encontrada\"}");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallback(async context =>
                {
                    if (context.Request.Method != "GET" && context.Request.Method != "DELETE")
                    {
                        context.Response.StatusCode = 405;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("{\"error\": \"Método no permitido\"}");
                    }
                });
            });
        }
        public static void RegisterServices(IServiceCollection Services)
        {
            DependencyContainer.RegisterServices(Services);
        }
    }
}
