using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Data;
using LostInTime.Models;

namespace LostInTime.ViewModels
{
    public partial class CharacterAddViewModel : ViewModelBase
    {
        private readonly IRepository<Character> characterRepository;

        public CharacterAddViewModel(IRepository<Character> characterRepository)
        {
            this.characterRepository = characterRepository;
        }

        [ObservableProperty]
        private string? characterName;

        [ObservableProperty]
        private CharacterClass? characterClass;

        [RelayCommand]
        private async Task AddCharacter()
        {
            if (string.IsNullOrWhiteSpace(CharacterName) || CharacterClass is null)
            {
                return;
            }

            await characterRepository.Add(new Character() { Name = CharacterName, Class = CharacterClass.Value });
            await Navigator.NavigateBackAsync();
        }
    }
}
