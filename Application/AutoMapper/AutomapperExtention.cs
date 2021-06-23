using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
     public static class AutomapperExtention
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);


            return services;
        }

    }
}
