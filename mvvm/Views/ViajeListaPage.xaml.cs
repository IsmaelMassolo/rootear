using rootear.mvvm.ViewModels;
using rootear.Services;

namespace rootear.mvvm.Views;

public partial class ViajeListaPage : ContentPage
{
    public ViajeListaPage()
    {
        ViajeService service = new ViajeService();
        ViajeListaViewModel vm = new ViajeListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ViajeListaViewModel;

        if (vm != null)
        {
            await vm.GetViajesCommand.ExecuteAsync(null);
        }
    }

}