﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutofacSerilogIntegration;
using ProductionRepository;

namespace ProductionWebAPI
{
    /// <summary>
    /// Represent Autofac configuration.
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// Configured instance of <see cref="IContainer"/>
        /// <remarks><see cref="AutofacConfig.Configure"/> must be called before trying to get Container instance.</remarks>
        /// </summary>
        protected internal static IContainer Container;

        /// <summary>
        /// Initializes and configures instance of <see cref="IContainer"/>.
        /// </summary>
        /// <param name="config"></param>
        public static void Configure(HttpConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterLogger();
            builder.RegisterInstance(AutoMapperConfig.Configure(config));
            builder.RegisterType<ProductRepository>().As<IProductRepository>().WithParameters(new List<Parameter> { new NamedParameter("context", new ProductionDAL.ProductionContext())});

            RegisterServices(builder);

            Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

#pragma warning disable RECS0154 // Parameter is never used
        private static void RegisterServices(ContainerBuilder builder)
#pragma warning restore RECS0154 // Parameter is never used
        {
            // TODO: Register additional services for injection
        }
    }
}