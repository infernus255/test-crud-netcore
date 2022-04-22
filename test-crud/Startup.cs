using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using test_crud.core.Interfaces;
using test_crud.core.Options;
using test_crud.core.Services;
using test_crud.infrastructure.Data;
using test_crud.infrastructure.Filters;
using test_crud.infrastructure.Interfaces;
using test_crud.infrastructure.Repositories;
using test_crud.infrastructure.Services;

namespace test_crud
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Filters, Behaviors, Serializer Settings
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>())
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    //option.SupressModelStateInvalidFilter = true;
                });
            //Dependency Injection
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
            //Authentication JWT
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateActor = true,

                    ValidIssuer = Configuration["Autentication:Issuer"],
                    ValidAudience = Configuration["Autentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Autentication:SecretKey"]))
                };
            });
            //Configuration Options
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            //Connection String
            services.AddDbContext<TestCrudContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("test_crud"))
            );
            //AutoMapper register
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Crud API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            //Validators
            services.AddMvc().AddFluentValidation(options => options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Crud API");
                    options.RoutePrefix = String.Empty;
                }
            );

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
