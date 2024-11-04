using rootear.Services;
using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views;

public partial class ReservaPage : ContentPage
{
    public ReservaPage()
    {
        ReservaService service = new ReservaService();
        ReservaViewModel vm = new ReservaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ReservaViewModel;

        if (vm != null && vm.GetViajesDelUsuarioCommand.CanExecute(null))
        {
            await vm.GetViajesDelUsuarioCommand.ExecuteAsync(null);
        }
    }
}