using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LostInTime.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LostInTime.Navigation
{
    public class NavigationResolver : INavigationResolver
    {
        private readonly IServiceProvider serviceProvider;

        public NavigationResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<ViewModelBase?> GetViewModelForType(Type type)
        {
            return Task.FromResult(serviceProvider.GetService(type) as ViewModelBase);
        }

        public Task<ViewModelBase?> GetViewModelForType<VM>() where VM : ViewModelBase
        {
            return Task.FromResult<ViewModelBase?>(serviceProvider.GetService<VM>());
        }
    }
}
