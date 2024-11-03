using rootear.mvvm.Models;
using rootear.Services;
using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views;

public partial class ViajeDetallePage : ContentPage
{
    public ViajeDetallePage(Viaje param)
    {
        InitializeComponent();
        ViajeService viaje = new ViajeService();
        ReservaService service = new ReservaService();
        ViajeDetalleViewModel vm = new ViajeDetalleViewModel(service, viaje);
        this.BindingContext = vm;
        vm.Viaje = param;
    }
}