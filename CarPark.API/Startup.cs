using CarPark.API.Controllers;
using CarPark.API.Data;
using CarPark.API.Data;
using CarPark.API.Data.BookingOffices;
using CarPark.API.Data.Cars;
using CarPark.API.Data.Employees;
using CarPark.API.Data.Parks;
using CarPark.API.Data.Tickets;
using CarPark.API.Data.Trips;
using CarPark.API.Services.BookingOffices;
using CarPark.API.Services.Cars;
using CarPark.API.Services.Employees;
using CarPark.API.Services.Parks;
using CarPark.API.Services.Tickets;
using CarPark.API.Services.Trips;
using CarPark.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarPark.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                 {
                   new OpenApiSecurityScheme
                   {
                     Reference = new OpenApiReference
                     {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                     }
                    },
                    new string[] { }
                  }
                });
            });


            services.AddDbContext<CarParkDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CarParkConnection")));
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IBookingOfficeRepo, BookingOfficeRepo>();
            services.AddScoped<IBookingOfficeServices, BookingOfficeServices>();
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<ICarServices, CarServices>(); 
            services.AddScoped<ITicketRepo, TicketRepo>();
            services.AddScoped<ITicketServices, TicketServices>(); 
            services.AddScoped<ITripRepo, TripRepo>();
            services.AddScoped<ITripServices, TripServices>(); 
            services.AddScoped<IParkRepo, ParkRepo>();
            services.AddScoped<IParkServices, ParkServices>();

            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new CustomConverter()));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            }
            );

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarPark.API v1"));
            }

            app.UseHttpsRedirection();

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
