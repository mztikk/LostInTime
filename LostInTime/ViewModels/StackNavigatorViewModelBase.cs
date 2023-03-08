using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LostInTime.Navigation;

namespace LostInTime.ViewModels
{
    public abstract partial class StackNavigatorViewModelBase : ViewModelBase, INavigator
    {
        private readonly INavigationResolver navigationResolver;

        protected StackNavigatorViewModelBase(INavigationResolver navigationResolver)
        {
            this.navigationResolver = navigationResolver;

            navigationStack = new();
        }

        [ObservableProperty]
        private ViewModelBase? currentPage;

        [ObservableProperty]
        private Stack<ViewModelBase> navigationStack;

        public async Task NavigateToAsync(ViewModelBase viewModel)
        {
            viewModel.Navigator = this;
            NavigationStack.Push(viewModel);
            CurrentPage = viewModel;
            await viewModel.OnNavigatedToAsync();
        }

        public async Task NavigateToAsync<VM>() where VM : ViewModelBase
        {
            ViewModelBase? viewModel = await navigationResolver.GetViewModelForType<VM>();
            await NavigateToAsync(viewModel);
        }

        public async Task NavigateToAsync(Type viewModelType)
        {
            ViewModelBase? viewModel = await navigationResolver.GetViewModelForType(viewModelType) as ViewModelBase;
            await NavigateToAsync(viewModel);
        }

        public async Task NavigateBackAsync()
        {
            NavigationStack.Pop();
            CurrentPage = navigationStack.LastOrDefault();
            await CurrentPage?.OnNavigatedToAsync();
        }
    }
}
