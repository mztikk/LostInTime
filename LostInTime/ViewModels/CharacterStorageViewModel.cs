using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Data;
using LostInTime.Models;

namespace LostInTime.ViewModels
{
    public partial class CharacterStorageViewModel : ViewModelBase
    {
        private readonly IRepository<Character> characterRepository;

        public CharacterStorageViewModel(IRepository<Character> characterRepository)
        {
            this.characterRepository = characterRepository;
        }

        [ObservableProperty]
        private ObservableCollection<Character> characters;

        [RelayCommand]
        private async Task AddNewCharacter()
        {
            await Navigator.NavigateToAsync<CharacterAddViewModel>();
        }

        [RelayCommand]
        private async Task RemoveCharacter(Character character)
        {
            await characterRepository.Delete(character);
            Characters.Remove(character);
        }

        public override Task OnNavigatedToAsync()
        {
            Characters = new(characterRepository.Get());
            return Task.CompletedTask;
        }
    }
}
