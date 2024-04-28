namespace Maui.DataGrid.Sample;

using CommunityToolkit.Maui.Views;
using Maui.DataGrid.Sample.Models;
using Maui.DataGrid.Sample.ViewModels;
using System.Diagnostics;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainViewModel
        {
            Columns = _dataGrid1.Columns
        };

        _dataGrid1.ItemSelected += DataGrid1_ItemSelected;
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        var vm = (MainViewModel)BindingContext;
        var settingsPopup = new SettingsPopup(vm);
        _ = await Shell.Current.ShowPopupAsync(settingsPopup);
    }

    private void DataGrid1_ItemSelected(object? sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine($"Current selection: {((Team)e.CurrentSelection[0]).Name}");
    }
}
