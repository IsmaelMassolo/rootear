using rootear.mvvm.Models;
using rootear.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using rootear.mvvm.Models.DTO;
using rootear.mvvm.Views;

namespace rootear.mvvm.ViewModels;

public partial class ReservaViewModel : BaseViewModel
{



    [ObservableProperty] Reserva reserva;
    public ObservableCollection<DetalleReserva> Viajes { get; } = new();
    [ObservableProperty] private DetalleReserva _viajesEnReserva;
    [ObservableProperty]
    private ObservableCollection<Viaje> viajesFiltrados = new();

    [ObservableProperty] bool isRefreshing;
    [ObservableProperty] Viaje viajeSeleccionado;
    IReservaService _reservaService;


    public ReservaViewModel(IReservaService reservaService)
    {
        Title = "Tu Reserva";
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

                foreach (var viaje in viajes)
                {
                    viajesFiltrados.Add(viaje);

                }
            }

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();

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
        // Navegar a MainPage
        await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
    }
}