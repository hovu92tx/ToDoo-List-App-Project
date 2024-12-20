using ToDoo.ViewModels;
namespace ToDoo.Views;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
        ItemsListView.ItemSelected += (s, e) => ItemsListView.SelectedItem = null;
    }
}