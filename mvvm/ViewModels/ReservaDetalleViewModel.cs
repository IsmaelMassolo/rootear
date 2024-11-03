using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.mvvm.Views;
using rootear.Services;
using rootear.Utils;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels
{
    public partial class ReservaDetalleViewModel : BaseViewModel
    {

        [ObservableProperty] Viaje viaje;
        [ObservableProperty] DetalleReserva detalleReserva;





        IReservaService _reservaService;
        IViajeService _viajeService;

        //[ObservableProperty] DetalleReserva _detalleReserva;




        public ReservaDetalleViewModel(IReservaService reservaService, IViajeService viajeService)
        {
            Title = "Detalles";
            _reservaService = reservaService;
            _viajeService = viajeService;
   
        }


        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        [RelayCommand]
        private async Task EliminarViajeAsync()
        {
            try
            {
                if (viaje == null)
                {
                    return;
                }

                DetalleReservaDTO dto = new DetalleReservaDTO
                {
                    IdSalaReserva = Transport.IdSalaReserva,
                    IdViaje = viaje.IdViaje,
                    FechaAgregado = DateTime.Now
                };

                // Llamar al servicio para eliminar el viaje
                var resultado = await _reservaService.EliminarViajeAsync(dto);

                if (resultado)
                {
                    await Application.Current.MainPage.DisplayAlert("Si!", "Ya no estas anotadx en este viaje!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
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
    }
}