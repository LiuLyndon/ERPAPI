using ERPAPI.Auth;
using GlobalLib.DataContext;
using GlobalLib.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Linq;

namespace ERPAPI
{
    /// <summary>
    /// Start up
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // ------------------------------------
            // OData
            services.AddControllers().AddOData();

            // ConnectionStrings con = new ConnectionStrings();
            // Configuration.Bind("ConnectionStrings", con);
            // Add Singleton
            // services.AddSingleton(con);
            // ------------------------------------
            // Add OpenAPI v3 document
            services.AddOpenApiDocument();
            // ------------------------------------
            // Add Cors
            // CORS is only for xhr request. 
            services.AddCors(options =>
            {
                // CorsPolicy 是自訂的 Policy 名稱
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy
#if fa
                        .AllowAnyOrigin()
#else
                        .WithOrigins(
                                        "http://127.0.0.1:4200",
                                        "http://127.0.0.1"
                                    )
#endif
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                    //.AllowCredentials();
                });
            });
            // ------------------------------------
            // JWT
            var jwtSettings = Configuration.GetSection("JwtSettings");
            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.GetSection("ValidIssuer").Value,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings.GetSection("ValidAudience").Value,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.GetSection("SignatureKey").Value)),
                        ValidateLifetime = true
                    };
                });
            services.AddScoped<JwtHandler>();
            // ------------------------------------
            // JSON 屬性名大寫變小寫
            services.AddMvc().AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);
            // ------------------------------------
            // DbContext
            //services.AddControllers();
            // Go to your API Project and open the startup.cs file. Modify the ConfigureService method and create the DBContextPool like below.
            services.AddDbContext<V_EIPContext>(options =>
                      options.UseSqlServer(
                          Configuration.GetConnectionString("V_EipConnection")));
            //Register dapper in scope    
            services.AddScoped<IDapper, V_EipDapper>();

            // ------------------------------------
            // Workaround: https://github.com/OData/WebApi/issues/1177
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ------------------------------------
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // ------------------------------------
#if true
            app.UseOpenApi();       // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3();    // serve Swagger UI
#endif
            // ------------------------------------
            // 1.
            app.UseRouting();
            // 2.Add Cors
            app.UseCors("CorsPolicy");

            // JWT
            // ------------------------------------
            // STEP2: 使用驗證權限的 Middleware
            app.UseAuthentication();
            app.UseAuthorization();
            // ------------------------------------
            // app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);
            // ------------------------------------
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
            // ------------------------------------
            // NSwag
            // https://github.com/RicoSuter/NSwag/wiki/AspNetCore-Middleware
            app.UseOpenApi(); // serve documents (same as app.UseSwagger())
            app.UseSwaggerUi3(); // serve Swagger UI
            //app.UseReDoc(config =>  // serve ReDoc UI
            //{
                // 這裡的 Path 用來設定 ReDoc UI 的路由 (網址路徑) (一定要以 / 斜線開頭)
                // config.Path = "/swagger/v1/swagger.json";
            //});
        }
    }
}
