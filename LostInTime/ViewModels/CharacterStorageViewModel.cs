using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Models;

namespace LostInTime.ViewModels
{
    public partial class CharacterStorageViewModel : ViewModelBase
    {
        private readonly CharacterContext characterContext;

        public CharacterStorageViewModel(CharacterContext characterContext)
        {
            this.characterContext = characterContext;
        }

        [ObservableProperty]
        private ObservableCollection<Character> characters;

        [RelayCommand]
        private async Task AddNewCharacter()
        {
            await Navigator.NavigateToAsync<CharacterAddViewModel>();
        }

        [RelayCommand]
        private void RemoveCharacter(Character character)
        {
            characterContext.Remove(character);
            Characters.Remove(character);
            characterContext.SaveChanges();
        }

        public override async Task OnNavigatedToAsync()
        {
            Characters = new(characterContext.Characters);
        }
    }
}
