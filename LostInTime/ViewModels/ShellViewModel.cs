using CommunityToolkit.Mvvm.ComponentModel;
using LostInTime.Navigation;

namespace LostInTime.ViewModels
{
    public partial class ShellViewModel : StackNavigatorViewModelBase
    {
        public ShellViewModel(INavigationResolver navigationResolver) : base(navigationResolver)
        {
        }
    }
}
