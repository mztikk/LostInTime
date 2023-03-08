using Avalonia;
using Avalonia.Controls;

namespace LostInTime.Views;

public partial class CharacterAddView : UserControl
{
    public CharacterAddView()
    {
        InitializeComponent();
    }

    public void CharacterNameTextBoxAttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs args)
    {
        (sender as TextBox)?.Focus();
    }
}