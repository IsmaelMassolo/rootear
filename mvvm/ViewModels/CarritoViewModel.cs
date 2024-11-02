//using rootear.mvvm.Models;
//using rootear.mvvm.Services;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Collections.ObjectModel;

//namespace rootear.mvvm.ViewModels;

//public partial class CarritoViewModel : BaseViewModel
//{
//    [ObservableProperty] Carrito carrito;
//    public ObservableCollection<ViajeCarrito> Viajes { get; } = new();
//    [ObservableProperty] private ViajeCarrito _viajesEnCarrito;
//    IReservaService _carritoService;
//    [ObservableProperty] private int esVisible = Transport.RolUsuario;

//    public CarritoViewModel(IReservaService carritoService)
//    {
//        Title = "Tu Carrito";
//        _carritoService = carritoService;
//    }

//    [RelayCommand]
//    private async Task EliminarViajeAsync(ViajeCarrito viaje)
//    {
//        try
//        {
//            var dto = new EliminarViajeCarritoDTO
//            {
//                IdCarrito = viaje.IdCarrito,
//                IdViaje = viaje.IdViaje,
//                Cantidad = viaje.Cantidad
//            };

//            // Llamar al servicio para eliminar el viaje
//            var resultado = await _carritoService.EliminarViajeAsync(dto);

//            if (resultado)
//            {
//                // Si es exitoso, eliminar el viaje localmente
//                Viajes.Remove(viaje);
//            }
//            else
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el viaje.", "OK");
//            }
//        }
//        catch (Exception ex)
//        {
//            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
//        }
//    }


//    [RelayCommand]
//    private async Task GetViajesDelUsuario()
//    {
//        try
//        {

//            var viajes = await _carritoService.GetViajeCarritoPorId(Transport.IdUsuario);

//            if (viajes != null)
//            {
//                Viajes.Clear();
//                foreach (var viaje in viajes)
//                {
//                    Viajes.Add(viaje);
//                }
//            }

//            var response = await _carritoService.GetCarritoPorId(Transport.IdUsuario);
//            if (response != null)
//            {
//                carrito = response;
//                OnPropertyChanged(nameof(Carrito));
//            }
//            else
//            {
//                throw new Exception("Carrito no encontrado.");
//            }
//        }
//        catch (Exception exception)
//        {
//            throw new Exception(exception.Message);
//        }
//    }

//    [RelayCommand]
//    private async Task GoBack()
//    {
//        await Application.Current.MainPage.Navigation.PopAsync();
//    }


//    [RelayCommand]
//    private async Task FinalizarCompraAsync()
//    {
//        try
//        {
//            // Verificar si hay viajes en el carrito
//            if (Viajes.Count == 0)
//            {
//                await Application.Current.MainPage.DisplayAlert("Aviso", "No tienes viajes en el carrito para finalizar la compra.", "OK");
//                return;
//            }

//            if (string.IsNullOrEmpty(Transport.Direccion))
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "La dirección de entrega no está disponible.", "OK");
//                return;
//            }

//            var dtos = new List<EliminarViajeCarritoDTO>();

//            foreach (var viaje in Viajes)
//            {
//                var dto = new EliminarViajeCarritoDTO
//                {
//                    IdCarrito = viaje.IdCarrito,
//                    IdViaje = viaje.IdViaje,
//                    Cantidad = viaje.Cantidad
//                };
//                dtos.Add(dto);
//            }
//            var resultadoGeneral = true;

//            foreach (var dto in dtos)
//            {
//                var resultado = await _carritoService.EliminarViajeAsync(dto);
//                if (!resultado)
//                {
//                    resultadoGeneral = false;
//                    break; 
//                }
//            }

//            if (resultadoGeneral)
//            {
//                await Application.Current.MainPage.DisplayAlert(
//                    "Felicitaciones por tu compra!",
//                    $"Tu paquete será entregado en: {Transport.Direccion}",
//                    "Aceptar");

//                Viajes.Clear();

//                await Application.Current.MainPage.Navigation.PopToRootAsync();
//            }
//            else
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar uno o más viajes del carrito.", "OK");
//            }
//        }
//        catch (Exception ex)
//        {
//            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
//        }
//    }


//}