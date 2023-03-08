using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using LostInTime.ViewModels;

namespace LostInTime
{
    public class ViewLocator : IDataTemplate
    {
        private readonly IServiceProvider serviceProvider;

        public ViewLocator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IControl Build(object data)
        {
            string name = data.GetType().FullName!.Replace("ViewModel", "View");
            Type? type = Type.GetType(name);

            if (type != null && serviceProvider.GetService(type) is Control control)
            {
                return control;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
