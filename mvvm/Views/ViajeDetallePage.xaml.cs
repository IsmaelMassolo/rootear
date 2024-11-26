using rootear.mvvm.Models;
using rootear.mvvm.ViewModels;
using rootear.Services;

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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Obt�n las ciudades de origen y destino desde tu ViewModel
        var origenCiudad = ((ViajeDetalleViewModel)BindingContext).Viaje.Origen.Ciudad;
        var destinoCiudad = ((ViajeDetalleViewModel)BindingContext).Viaje.Destino.Ciudad;
        // Configura la URL de Google Maps con los datos de origen y destino
        var mapsUrl = $"https://www.google.com/maps/dir/?api=1&origin={origenCiudad}&destination={destinoCiudad}&travelmode=driving";
        // Cargar la URL en el WebView
        mapWebView.Source = mapsUrl;
    }
}

