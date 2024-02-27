using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services;
using System.Data.SqlClient;

namespace API
{
    public static class Startup
    {
        public static WebApplication ConfigureWebApplication(WebApplicationBuilder builder)
        {
            ConfigureCors(builder.Services);
            ConfigureServices(builder.Services, builder.Configuration);
            ConfigureControllers(builder.Services);

            if (builder.Environment.IsDevelopment())
            {
                ConfigureSwagger(builder.Services);
            }

            return ConfigureApp(builder.Build());
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            // Default Policy
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200");
                });
            });
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            ConfigureInfrastructureService(services, config);
            services.ConfigureAllServices(config);

            // Add HttpContextAccessor
            services.AddHttpContextAccessor();
        }

        private static void ConfigureInfrastructureService(IServiceCollection services, IConfiguration config)
        {
            services.Add(new ServiceDescriptor(typeof(SqlConnection), serviceProvider => new SqlConnection(config.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped));

            services.AddDbContext<CRMContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }

        private static void ConfigureControllers(IServiceCollection services)
        {
            // Add Controllers to the container.
            services.AddControllers();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });
        }


        private static WebApplication ConfigureApp(WebApplication app)
        {
            // Enable CORS
            app.UseCors(options =>
            {
                options
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:4200");
            });

            // Use the Developer Exception Page in Development
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // Use exception handling middleware appropriate for production
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Use HTTPS redirection in production
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Enable routing
            app.UseRouting();

            app.MapControllers();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
