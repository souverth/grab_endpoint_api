using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;


namespace IOT_Server_Endpoint_Grab.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var serviceTypes = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.Namespace == "BASE_TEST.Services");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("________________Reg Service________________");
            Console.ResetColor();

            foreach (var serviceType in serviceTypes)
            {
                var interfaces = serviceType.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    Console.WriteLine($"Registering {serviceType.Name} as {@interface.Name}");
                    services.AddScoped(@interface, serviceType);
                }

                // Đăng ký lớp dịch vụ nếu không có interface
                services.AddScoped(serviceType);
            }
            Console.WriteLine("___________________________________________");

            return services;
        }
    }
}
