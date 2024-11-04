using rootear.mvvm.Models;
using rootear.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using rootear.mvvm.Models.DTO;
using rootear.mvvm.Views;

namespace rootear.mvvm.ViewModels
{
    public partial class HistorialViewModel : BaseViewModel
    {
        //[ObservableProperty] private DetalleReserva _viajesEnReserva;
        [ObservableProperty] private ObservableCollection<Viaje> viajesFiltrados = new();
        [ObservableProperty] bool isRefreshing;
        [ObservableProperty] Viaje viajeSeleccionado;
        IHistorialService _historialService;

        public HistorialViewModel(IHistorialService historialService)
        {
            _historialService = historialService;
        }

        [RelayCommand]
        private async Task GetViajesDelUsuario()
        {
            try
            {
                var viajes = await _historialService.GetHistorialPorId(); //GetDetalleReservaPorId()

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
        private async Task GoToMainPage()
        {
            // Navegar a MainPage
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

    }
}