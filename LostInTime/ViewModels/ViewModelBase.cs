using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LostInTime.ViewModels
{
    public abstract partial class ViewModelBase : ObservableObject
    {
        public virtual Task OnNavigatedToAsync()
        {
            return Task.CompletedTask;
        }

        [ObservableProperty]
        private INavigator navigator;
    }
}
