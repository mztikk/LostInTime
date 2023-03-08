using System;
using System.Threading.Tasks;

namespace LostInTime.ViewModels
{
    public interface INavigator
    {
        Task NavigateToAsync(ViewModelBase viewModel);

        Task NavigateToAsync<VM>() where VM : ViewModelBase;
        Task NavigateToAsync(Type viewModelType);
        Task NavigateBackAsync();
    }
}
