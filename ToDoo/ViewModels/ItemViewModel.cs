using System;
using ToDoo.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoo.Models;
using ToDoo.Views;
namespace ToDoo.ViewModels
{
    public partial class ItemViewModel:ViewModel
    {
        private readonly ITodoRepository repository;
        private readonly IServiceProvider services;
        [ObservableProperty]
        TodoItem item;
        public ItemViewModel(ITodoRepository repository, IServiceProvider services)
        {
            this.repository = repository;
            this.services = services;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1)};
        }

        [RelayCommand]
        public async Task SaveButton() 
        {
            await repository.AddOrUpdate(Item);
            await Navigation.PushAsync(services.GetRequiredService<MainView>());
        }
        [RelayCommand]
        public async Task DeleteButton()
        {
            await repository.DeletedItemAsync(Item);
            await Navigation.PushAsync(services.GetRequiredService<MainView>());
        }
    }
}
