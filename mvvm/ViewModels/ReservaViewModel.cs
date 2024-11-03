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
    private async Task EliminarViajeAsync(DetalleReserva viaje)
    {
        try
        {
            var dto = new DetalleReservaDTO
            {
                IdSalaReserva = viaje.IdSalaReserva,
                IdViaje = viaje.IdViaje,
                FechaAgregado = viaje.FechaAgregado
            };

            // Llamar al servicio para eliminar el viaje
            var resultado = await _reservaService.EliminarViajeAsync(dto);

            if (resultado)
            {
                // Si es exitoso, eliminar el viaje localmente
                Viajes.Remove(viaje);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el viaje.", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
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
        //await Application.Current.MainPage.Navigation.PushAsync(new ViajeDetallePage(viajeSeleccionado), true);
    }

    [RelayCommand]
    private async Task GoToMainPage()
    {
        // Navegar a MainPage
        await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
    }
}