using System;
using CustomerAssignment.Common.Core.EventBus;
using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Common.Core.Repositories;
using CustomerAssignment.Common.Infrastructure.EventBus.InMemoryEventBus;
using CustomerAssignment.Common.Infrastructure.EventStore.InMemoryEventStore;
using CustomerAssignment.Customers.Application.Mappers;
using CustomerAssignment.Customers.Application.Services;
using CustomerAssignment.Customers.Application.Validations;
using CustomerAssignment.Customers.API.Middlewares;
using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.Buses;
using CustomerAssignment.Customers.Domain.Factories;
using CustomerAssignment.Customers.Domain.Handlers;
using CustomerAssignment.Customers.Infrastructure.ReadModel.InMemory;
using CustomerAssignment.Customers.Infrastructure.ReadModel.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAssignment.Customers.API
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
            services.AddCors();
            services.AddMvc();

            services.AddTransient<ICustomerCommandService, CustomerCommandService>();
            services.AddTransient<ICustomerCommandMapper, CustomerCommandMapper>();
            services.AddTransient<ICustomerCommandValidation, CustomerCommandValidation>();
            services.AddTransient<ICustomerCommandBus, CustomerCommandBus>();
            services.AddTransient<ICustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<ICustomerFactory, CustomerFactory>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IEventStore, InMemoryEventStore>();
            services.AddSingleton<IEventBus, InMemoryEventBus>();
            services.AddTransient<ICustomerEventHandler, CustomerEventHandler>();
            services.AddSingleton<ICustomerContactCardRepository, CustomerContactCardRepository>();
            services.AddSingleton<ICustomerListRepository, CustomerListRepository>();
            services.AddTransient<ICustomerQueryService, CustomerQueryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            serviceProvider.GetService<ICustomerEventHandler>();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:50611").AllowAnyHeader();
            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id?}");
            });
        }
    }
}
