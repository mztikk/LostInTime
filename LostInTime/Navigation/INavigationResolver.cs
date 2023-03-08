using System;
using System.Threading.Tasks;
using LostInTime.ViewModels;

namespace LostInTime.Navigation
{
    public interface INavigationResolver
    {
        Task<ViewModelBase?> GetViewModelForType(Type type);
        Task<VM?> GetViewModelForType<VM>() where VM : ViewModelBase;
    }
}