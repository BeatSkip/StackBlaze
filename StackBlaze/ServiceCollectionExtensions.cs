using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BlazorStyled;

namespace StackBlaze
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStackBlaze(this IServiceCollection services)
        {
            services.AddBlazorStyled();
            return services.AddSingleton<StackBlazeService>();
        }
    }
}
