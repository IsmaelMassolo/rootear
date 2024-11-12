using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Views;
using rootear.Services;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels
{
    public partial class HistorialViewModel : BaseViewModel
    {
        [ObservableProperty] private ObservableCollection<Viaje> viajesFiltrados = new();
        [ObservableProperty] Viaje viajeSeleccionado;
        IHistorialService _historialService;
        [ObservableProperty] bool isRefreshing;

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
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}