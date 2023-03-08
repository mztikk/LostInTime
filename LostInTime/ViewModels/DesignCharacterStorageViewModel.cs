using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Models;

namespace LostInTime.ViewModels
{
    public partial class DesignCharacterStorageViewModel : ViewModelBase
    {
        public DesignCharacterStorageViewModel()
        {
            characters = new() {
                new Character(){ CharacterId = 1, Class=CharacterClass.Berserker, Name= "Name 1", Level=60, ItemLevel=1460 },
                new Character(){ CharacterId = 2, Class=CharacterClass.Reaper, Name= "Name 2", Level=50, ItemLevel=700 },
                new Character(){ CharacterId = 3, Class=CharacterClass.Destroyer, Name= "Name 3", Level=52, ItemLevel=1370 },
            };
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
            _ = Characters.Remove(character);
        }
    }
}
