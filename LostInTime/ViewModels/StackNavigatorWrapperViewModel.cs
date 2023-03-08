using LostInTime.Navigation;

namespace LostInTime.ViewModels
{
    public class StackNavigatorWrapperViewModel : StackNavigatorViewModelBase
    {
        public StackNavigatorWrapperViewModel(INavigationResolver navigationResolver) : base(navigationResolver)
        {
        }
    }
}
