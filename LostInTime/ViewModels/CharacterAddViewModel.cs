using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostInTime.Models;
using Microsoft.EntityFrameworkCore;

namespace LostInTime.ViewModels
{
    public partial class CharacterAddViewModel : ViewModelBase
    {
        private readonly CharacterContext characterContext;

        public CharacterAddViewModel(CharacterContext characterContext)
        {
            this.characterContext = characterContext;
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

            await characterContext.AddAsync(new Character() { Name = CharacterName, Class = CharacterClass.Value });
            await characterContext.SaveChangesAsync();
            await Navigator.NavigateBackAsync();
        }
    }
}
