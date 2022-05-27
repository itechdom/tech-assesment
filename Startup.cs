using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft;
using Newtonsoft.Json.Serialization;

namespace justice_technical_assestment
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment Env)
        {
            Configuration = configuration;
            env = Env;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment env;

        public void ConfigureServices(IServiceCollection services)
        {
            //Authentication
            // services.AddAuthentication("Bearer")
            //   .AddIdentityServerAuthentication("Bearer", options =>
            //   {
            //       options.Authority = Configuration["AppSettings:issuerUri"];
            //       options.RequireHttpsMetadata = false;
            //   });

            //Authorization
            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy(Configuration["AppSettings:required_scopes"], policy =>
            //     {
            //         policy.RequireAuthenticatedUser();
            //         policy.RequireClaim("scope", Configuration["AppSettings:required_scopes"]);
            //     });
            // });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddHttpContextAccessor();
            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                })
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            AddApplicationServices(services);
        }

        public HttpClientHandler ConfigureSSL()
        {
            var handler = new HttpClientHandler();
            if (env.IsDevelopment())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            }
            return handler;
        }

        public void AddApplicationServices(IServiceCollection services)
        {
            // services.AddTransient<SearchItemsByPhoneProxy>();

            //
        }

        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseSwaggerUI(options =>
            {
                if (env.IsDevelopment())
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    //options.RoutePrefix = string.Empty;
                }
                else
                    options.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });
        }
    }
}