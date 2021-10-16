using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extentions
{
    public static class ServicesCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
