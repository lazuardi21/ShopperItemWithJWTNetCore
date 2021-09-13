using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Services;
using WNTS_V1._0._2.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
//using Microsoft.AspNetCore.Session;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Antiforgery;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

namespace WNTS_V1._0._2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration
        {
            get;
        }
        // This method gets called by the runtime. Use this method to add services to the container.  
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});
            //services.AddSingleton<IConfiguration>(Configuration);

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(0);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
            });
            //services.AddControllers();
            services.AddControllers()
               .AddNewtonsoftJson(opt =>
                     opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // configure strongly typed settings object conf in helpers
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddTransient<IGasComponent, GasComponentService>();
            services.AddScoped<IGasOperation, GasOperationService>();
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IGasCoOp, GasCoOpService>();




            //services.AddMvc().AddRazorPagesOptions(options => {
            //    options.Conventions.AddPageRoute("/GasComponent/Index", "");
            //});

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
                app.UseHsts();
            }


            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("MyPolicy");

            // custom jwt auth middleware
            //app.UseSession();
            app.UseMiddleware<JwtMiddleware>();
            
            //app.UseAuthorization();
            //app.UseAuthentication();
            //app.UseEndpoints(endpoints => {
            //    endpoints.MapControllerRoute(name: "default", pattern: "{controller=GasComponent}/{action=Index}/{id?}");
            //});
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}