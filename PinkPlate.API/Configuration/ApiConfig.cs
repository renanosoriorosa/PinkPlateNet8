using System.Text.Json.Serialization;
using Asp.Versioning;

namespace PinkPlate.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;//assume q tem uma versao default
                options.DefaultApiVersion = new ApiVersion(1, 0);//defione a versao default
                options.ReportApiVersions = true;//serve para informar ao client se a versao q ele ta consumindo é ou n bsoleta
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";//define o padrao pra ex: v2.3.1
                options.SubstituteApiVersionInUrl = true;//serve pra caso n especifique a versao da api, ele joga automaticamente pra versao default
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");

            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            return app;
        }
    }
}
