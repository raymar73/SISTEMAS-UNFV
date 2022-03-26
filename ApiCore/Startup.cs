using JWT;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ApiBussinessLogic.Implementations.Alumno;
using ApiBussinessLogic.Implementations.Login;
using ApiBussinessLogic.Interfaces.Alumno;
using ApiBussinessLogic.Interfaces.Login;

namespace ApiCore
{
    using ApiDataAccess;
    using ApiUnitWork;
    using ExternalServices;
    using ExternalServices.GoogleCaptcha;
    using JWT.Authentication;
    using JWT.TokenService;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;
    using System.Threading.Tasks;

    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<ITokenService, tokenServiceLogic>();

            services.AddTransient<ICaptchaGoogleService, CaptchaGoogleService>();
            services.AddTransient<ICredencialesLogic, credencialesLogic>();
            services.AddTransient<ITalumnoLogic, tAlumnoLogic>();


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUnitOfWork>(option => new UnitOfWork(Configuration.GetConnectionString("local")));
            var tokenProvider = new JwtProvider("issuer", "audience", "profexorrr_20000");
            services.AddSingleton<ITokenProvider>(tokenProvider);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins(Configuration["ServerCors"])
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    //options.RequireHttpsMetadata = false;
                    //options.TokenValidationParameters = tokenProvider.GetValidationParameters ();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.StatusCode = 401;
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    
                });

            
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_3_0);
            services.AddMvc (option => option.EnableEndpointRouting = false);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API SERVICES UNFV", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                        {
                            new OpenApiSecurityScheme
                            {
                            Reference = new OpenApiReference
                                {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                            }
                   });


                #region Agrega la documentación XML de todos los proyectos referenciados que lo generen
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                    .Union(new AssemblyName[] { currentAssembly.GetName() })
                    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                    .Where(File.Exists).ToArray();
                Array.ForEach(xmlDocs, (d) =>
                {
                    c.IncludeXmlComments(d);
                });
                #endregion

            });

        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage ();
                IdentityModelEventSource.ShowPII = true;
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts ();
            }
            

            app.UseRouting();
            // CORS
            // https://docs.asp.net/en/latest/security/cors.html
            //app.UseHttpsRedirection ();
            //app.UseCors(builder =>
            //    builder.WithOrigins(Configuration["ServerCors"])
            //        .AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod());
            app.UseCors("CorsApi");
            app.UseAuthentication ();
            app.UseAuthorization();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();
            app.UseMvc ();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0"); });
        }
    }
}