//using rootear.mvvm.Models;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using rootear.mvvm.Services; // Asegúrate de incluir el namespace del servicio
//using rootear.mvvm.Views;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text.Json;

//namespace rootear.mvvm.ViewModels
//{
//    public partial class ViajeDetalleViewModel : BaseViewModel
//    {
//        IReservaService _carritoService;
//        IViajeService _viajeService;
//        [ObservableProperty] Viaje viaje;
//        [ObservableProperty] ViajeCarrito viajeCarrito;
//        [ObservableProperty] private int esVisible = Transport.RolUsuario;

//        public ViajeDetalleViewModel(IReservaService carritoService, IViajeService viajeService)
//        {
//            Title = "Detalles";
//            _carritoService = carritoService;
//            _viajeService = viajeService;
//        }

//        [RelayCommand]
//        private async Task AgregarAlCarrito()
//        {

//            if (viaje == null)
//            {
//                return;
//            }

//            // Agrega el nuevo viaje al carrito
//            ViajeCarritoDTO viajeDTO = new ViajeCarritoDTO
//            {
//                IdUsuario = Transport.IdUsuario,
//                IdViaje = viaje.IdViaje,
//                Cantidad = 1
//            };

//            // Llamada al servicio para agregar el viaje al carrito
//            var resultado = await _carritoService.AgregarAlCarrito(viajeDTO);

//            if (resultado == true)
//            {
//                await Application.Current.MainPage.DisplayAlert("Si!", "Agregaste el libro a tu carrito de compras.", "OK");

//            }
//            else
//            {
//                await Application.Current.MainPage.DisplayAlert("Ups!", "Esta vez no pudo ser...", "OK");
//            }
//            await Application.Current.MainPage.Navigation.PushAsync(new ViajeListaPage());
//        }

//        [RelayCommand]
//        private async Task GoBack()
//        {
//            await Application.Current.MainPage.Navigation.PopAsync();
//        }

//        [RelayCommand]
//        private async Task EliminarViajeAsync()
//        {
//            if (viaje == null)
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "No hay un viaje seleccionado para eliminar.", "OK");
//                return;
//            }

//            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este viaje?", "Sí", "No");

//            if (confirm)
//            {
//                try
//                {
//                    bool result = await _viajeService.EliminarViajeAsync(viaje.IdViaje);

//                    if (result)
//                    {
//                        await Application.Current.MainPage.DisplayAlert("Éxito", "Viaje eliminado correctamente.", "OK");
//                        // Volver atrás en la navegación
//                        await GoBack();
//                    }
//                    else
//                    {
//                        await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el viaje.", "OK");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
//                }
//            }
//        }
//    }
//}