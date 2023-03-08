using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Navigation;

namespace LostInTime.ViewModels
{
    public partial class DashboardViewModel : StackNavigatorViewModelBase
    {

        public DashboardViewModel(INavigationResolver navigationResolver) : base(navigationResolver)
        {
        }

        [RelayCommand]
        public async Task OnTabChanged(Type type)
        {
            ArgumentNullException.ThrowIfNull(type);

            await NavigateToAsync(type);
        }
    }
}
