using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Views;
using rootear.Services;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels;

public partial class ReservaViewModel : BaseViewModel
{
    [ObservableProperty] private ObservableCollection<Viaje> viajesFiltrados = new();
    [ObservableProperty] bool isRefreshing;
    [ObservableProperty] Viaje viajeSeleccionado;
    IReservaService _reservaService;

    public ReservaViewModel(IReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [RelayCommand]
    private async Task GetViajesDelUsuario()
    {
        try
        {
            var viajes = await _reservaService.GetDetalleReservaPorId();

            if (viajes != null)
            {
                viajesFiltrados.Clear();
                foreach (var viaje in viajes) { viajesFiltrados.Add(viaje); }
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    [RelayCommand]
    private async Task GoToDetail()
    {
        if (viajeSeleccionado == null)
        {
            return;
        }
        await Application.Current.MainPage.Navigation.PushAsync(new ReservaDetallePage(viajeSeleccionado), true);
    }

    [RelayCommand]
    private async Task GoToMainPage()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
    }

    [RelayCommand]
    public async Task GoToViajeLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ViajeListaPage());
    }
}