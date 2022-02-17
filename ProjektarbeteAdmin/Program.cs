
using Microsoft.Extensions.DependencyInjection;
using Projektarbete.Services;
using Projektarbete.Services.Interfaces;
using ProjektarbeteAdmin;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
                .AddScoped<IProjectarbeteApi, ProjectarbeteAPI>()
                .AddScoped<IMenu, Menu>()
                .AddScoped<IEventService, EventService>()
            .BuildServiceProvider();

        //do the actual work here
        var menu = serviceProvider.GetService<IMenu>();
        menu.StartMenu();
    }
}
