using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using LostInTime.Navigation;
using LostInTime.ViewModels;
using LostInTime.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LostInTime
{
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            DataTemplates.Add(Services.GetService<ViewLocator>());

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);

                ShellViewModel? shellViewModel = Services.GetService<ShellViewModel>();

                desktop.MainWindow = new ShellView
                {
                    DataContext = shellViewModel,
                };

                shellViewModel.NavigateToAsync<DashboardViewModel>();
            }

            base.OnFrameworkInitializationCompleted();
        }

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();

            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            string dbPath = System.IO.Path.Join(path, "lostintime.db");
            services.AddDbContext<CharacterContext>(
            options =>
            {
                options.UseSqlite($"Data Source={dbPath}");
            });

            services.AddSingleton<ShellViewModel>()
                    .AddSingleton<ShellView>()
                    .AddTransient<INavigationResolver, NavigationResolver>()
                    .AddTransient<CharacterStorageViewModel>()
                    .AddTransient<CharacterStorageView>()
                    .AddTransient<CharacterAddViewModel>()
                    .AddTransient<CharacterAddView>()
                    .AddTransient<DashboardViewModel>()
                    .AddTransient<DashboardView>()
                    .AddSingleton<ViewLocator>();

            return services.BuildServiceProvider();
        }
    }
}
