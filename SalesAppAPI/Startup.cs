using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SalesAppAPI.Data;
using SalesAppAPI.Data.Repository;
using SalesAppAPI.Models.IRepository;
using TourApi.Mapping;

namespace SalesAppAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors(options =>
                    {
                        options.AddPolicy(MyAllowSpecificOrigins,
                        builder =>
                        {
                            builder.WithOrigins("http://127.0.0.1:3006",
                                                "http://localhost:3006")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials();
                        });
                    });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<SalesAppContext>(options =>
            {
                options.UseSqlite("Data Source=TourContext.db",
              x => x.MigrationsAssembly("SalesAppAPI"));

                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IComboRepository, ComboRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDeliveryNoteRepository, DeliveryNoteRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStorageRepository, StorageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
