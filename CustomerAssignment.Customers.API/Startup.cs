﻿using CustomerAssignment.Common.API.Middlewares;
using CustomerAssignment.Common.Core.Domain;
using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Common.Core.Repositories;
using CustomerAssignment.Common.Infrastructure.EventStore.InMemoryEventStore;
using CustomerAssignment.Customers.Application.Mappers;
using CustomerAssignment.Customers.Application.Services;
using CustomerAssignment.Customers.Application.Validations;
using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.Buses;
using CustomerAssignment.Customers.Domain.Factories;
using CustomerAssignment.Customers.Domain.Handlers;
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
            services.AddMvc();

            services.AddTransient<ICustomerCommandService, CustomerCommandService>();
            services.AddTransient<ICustomerCommandMapper, CustomerCommandMapper>();
            services.AddTransient<ICustomerCommandValidation, CustomerCommandValidation>();
            services.AddTransient<ICustomerCommandBus, CustomerCommandBus>();
            services.AddTransient<ICustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<ICustomerFactory, CustomerFactory>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IEventStore, InMemoryEventStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
