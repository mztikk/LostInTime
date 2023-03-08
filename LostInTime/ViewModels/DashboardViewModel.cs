using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Models;
using LostInTime.Navigation;

namespace LostInTime.ViewModels
{
    public partial class DashboardViewModel : StackNavigatorViewModelBase
    {

        public DashboardViewModel(INavigationResolver navigationResolver) : base(navigationResolver)
        {
            
        }

        [ObservableProperty]
        private ObservableCollection<TabItemModel> dashboardPages;

        [RelayCommand]
        public async Task OnTabChanged(Type type)
        {
            ArgumentNullException.ThrowIfNull(type);

            await NavigateToAsync(type);
        }

        public override async Task OnNavigatedToAsync()
        {
            //var characterPage = await navigationResolver.GetViewModelForType<CharacterStorageViewModel>();
            var characterPage = await navigationResolver.GetViewModelForType<StackNavigatorWrapperViewModel>();
            await characterPage.NavigateToAsync(await navigationResolver.GetViewModelForType<CharacterStorageViewModel>());

            var templateGroupEditorPage = await navigationResolver.GetViewModelForType<StackNavigatorWrapperViewModel>();
            await templateGroupEditorPage.NavigateToAsync(await navigationResolver.GetViewModelForType<TemplateGroupEditorViewModel>());

            DashboardPages = new()
            {
                new TabItemModel(){ Header="Characters", Content= characterPage },
                new TabItemModel(){ Header="Template Groups", Content= templateGroupEditorPage },
            };
        }
    }
}
