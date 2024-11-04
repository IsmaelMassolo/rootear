using rootear.Services;
using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views;

public partial class HistorialPage : ContentPage
{
    public HistorialPage()
    {
        HistorialService service = new HistorialService();
        HistorialViewModel vm = new HistorialViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as HistorialViewModel;

        if (vm != null && vm.GetViajesDelUsuarioCommand.CanExecute(null))
        {
            await vm.GetViajesDelUsuarioCommand.ExecuteAsync(null);
        }
    }
}