using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.mvvm.Views;
using rootear.Services;
using rootear.Utils;

namespace rootear.mvvm.ViewModels
{
    public partial class ViajeDetalleViewModel : BaseViewModel
    {
        IReservaService _reservaService;
        IViajeService _viajeService;
        [ObservableProperty] Viaje viaje;
        [ObservableProperty] DetalleReserva detalleReserva;
        [ObservableProperty] private string esVisible = Transport.Rol;

        public ViajeDetalleViewModel(IReservaService reservaService, IViajeService viajeService)
        {
            Title = "Detalles";
            _reservaService = reservaService;
            _viajeService = viajeService;
        }

        [RelayCommand]
        private async Task AgregarA_SalaReserva()
        {

            if (viaje == null)
            {
                return;
            }

            DetalleReservaDTO nuevaReservaDTO = new DetalleReservaDTO
            {
                IdSalaReserva = Transport.IdSalaReserva,
                IdViaje = viaje.IdViaje,
                FechaAgregado = DateTime.Now
            };

            var resultado = await _reservaService.AgregarA_DetalleReserva(nuevaReservaDTO);

            if (resultado == true)
            {
                await Application.Current.MainPage.DisplayAlert("Si!", "Agregaste un nuevo viaje! que lo disfrutes!", "OK");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ups!", "Esta vez no pudo ser...", "OK");
            }
            await Application.Current.MainPage.Navigation.PushAsync(new ViajeListaPage());
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //[RelayCommand]
        //private async Task EliminarViajeAsync()
        //{

        //    bool confirm = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este viaje?", "Sí", "No");

        //    if (confirm)
        //    {
        //        try
        //        {
        //            bool result = await _viajeService.EliminarViajeAsync(viaje.IdViaje);

        //            if (result)
        //            {
        //                await Application.Current.MainPage.DisplayAlert("Éxito", "Viaje eliminado correctamente, la próxima será", "OK");
        //                await GoBack();
        //            }
        //            else
        //            {
        //                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el viaje.", "OK");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        //        }
        //    }
        //}
    }
}