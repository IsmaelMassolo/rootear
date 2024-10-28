//using rootear.mvvm.Models;
//using rootear.mvvm.Services;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Collections.ObjectModel;

//namespace rootear.mvvm.ViewModels;

//public partial class CarritoViewModel : BaseViewModel
//{
//    [ObservableProperty] Carrito carrito;
//    public ObservableCollection<ProductoCarrito> Productos { get; } = new();
//    [ObservableProperty] private ProductoCarrito _productosEnCarrito;
//    IReservaService _carritoService;
//    [ObservableProperty] private int esVisible = Transport.RolUsuario;

//    public CarritoViewModel(IReservaService carritoService)
//    {
//        Title = "Tu Carrito";
//        _carritoService = carritoService;
//    }

//    [RelayCommand]
//    private async Task EliminarProductoAsync(ProductoCarrito producto)
//    {
//        try
//        {
//            var dto = new EliminarProductoCarritoDTO
//            {
//                IdCarrito = producto.IdCarrito,
//                IdProducto = producto.IdProducto,
//                Cantidad = producto.Cantidad
//            };

//            // Llamar al servicio para eliminar el producto
//            var resultado = await _carritoService.EliminarProductoAsync(dto);

//            if (resultado)
//            {
//                // Si es exitoso, eliminar el producto localmente
//                Productos.Remove(producto);
//            }
//            else
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el producto.", "OK");
//            }
//        }
//        catch (Exception ex)
//        {
//            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
//        }
//    }


//    [RelayCommand]
//    private async Task GetProductosDelUsuario()
//    {
//        try
//        {

//            var productos = await _carritoService.GetProductoCarritoPorId(Transport.IdUsuario);

//            if (productos != null)
//            {
//                Productos.Clear();
//                foreach (var producto in productos)
//                {
//                    Productos.Add(producto);
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
//            // Verificar si hay productos en el carrito
//            if (Productos.Count == 0)
//            {
//                await Application.Current.MainPage.DisplayAlert("Aviso", "No tienes productos en el carrito para finalizar la compra.", "OK");
//                return;
//            }

//            if (string.IsNullOrEmpty(Transport.Direccion))
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "La dirección de entrega no está disponible.", "OK");
//                return;
//            }

//            var dtos = new List<EliminarProductoCarritoDTO>();

//            foreach (var producto in Productos)
//            {
//                var dto = new EliminarProductoCarritoDTO
//                {
//                    IdCarrito = producto.IdCarrito,
//                    IdProducto = producto.IdProducto,
//                    Cantidad = producto.Cantidad
//                };
//                dtos.Add(dto);
//            }
//            var resultadoGeneral = true;

//            foreach (var dto in dtos)
//            {
//                var resultado = await _carritoService.EliminarProductoAsync(dto);
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

//                Productos.Clear();

//                await Application.Current.MainPage.Navigation.PopToRootAsync();
//            }
//            else
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar uno o más productos del carrito.", "OK");
//            }
//        }
//        catch (Exception ex)
//        {
//            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
//        }
//    }


//}