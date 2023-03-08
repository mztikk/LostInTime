using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LostInTime.Models;

namespace LostInTime.ViewModels
{
    public partial class TemplateGroupEditorViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<TemplateGroup> templateGroups;

        public override async Task OnNavigatedToAsync()
        {
            TemplateGroups = new() {
                new TemplateGroup()
                {
                    Name = "Name 1",
                    Items = new List<TemplateGroupItem>()
                    {
                        new CheckBoxTemplateGroupItem(){IsChecked=true},
                    },
                },
                new TemplateGroup()
                {
                    Name = "Name 2",
                    Items = new List<TemplateGroupItem>()
                    {
                        new CheckBoxTemplateGroupItem(){IsChecked=false},
                    },
                }
            };
        }
    }
}
