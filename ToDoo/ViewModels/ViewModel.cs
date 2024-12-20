using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoo.ViewModels
{
    [ObservableObject]
    public abstract partial class ViewModel
    {
        public INavigation Navigation { get; set; }
    }
}
