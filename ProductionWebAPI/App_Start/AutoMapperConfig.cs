using AutoMapper;
using ProductionDAL;
using ProductionWebAPI.Models;
using System;
using System.Web.Http;

namespace ProductionWebAPI
{
    public class AutoMapperConfig
    {
        protected internal static IMapper Mapper;

        static Func<Type, object> GetResolver(HttpConfiguration config) => type => config.DependencyResolver.GetService(type);

        public static IMapper Configure(HttpConfiguration config)
        {
            Action<IMapperConfigurationExpression> mapperConfigurationExp = cfg =>
            {
                cfg.ConstructServicesUsing(GetResolver(config));

                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();
            };

            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExp);
            Mapper = mapperConfiguration.CreateMapper();

            return Mapper;
        }
    }
}