using System.Text.Json.Serialization;

namespace Highfield.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors(x =>
            {
                x.AddPolicy("AllowHighfield.Client",
                    builder =>
                    {
                        builder
                        .WithOrigins(this._configuration["Highfield.HighfieldClient"]!)
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                    });
            });

            services.AddControllers();

            //services.AddScoped<IExternalApiService, ExternalApiService>(sp =>
            //{
            //    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();

            //    return new ExternalApiService(httpClientFactory);
            //});


            services.AddControllers().AddJsonOptions(x =>
                           x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseCors("AllowHighfield.Client");
            app.UseHttpsRedirection();
            app.UseRouting();

            // Add authentication and authorization middleware here if needed

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
