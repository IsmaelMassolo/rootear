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
//    public partial class ProductoDetalleViewModel : BaseViewModel
//    {
//        IReservaService _carritoService;
//        IViajeService _productoService;
//        [ObservableProperty] Producto producto;
//        [ObservableProperty] ProductoCarrito productoCarrito;
//        [ObservableProperty] private int esVisible = Transport.RolUsuario;

//        public ProductoDetalleViewModel(IReservaService carritoService, IViajeService productoService)
//        {
//            Title = "Detalles";
//            _carritoService = carritoService;
//            _productoService = productoService;
//        }

//        [RelayCommand]
//        private async Task AgregarAlCarrito()
//        {

//            if (producto == null)
//            {
//                return;
//            }

//            // Agrega el nuevo producto al carrito
//            ProductoCarritoDTO productoDTO = new ProductoCarritoDTO
//            {
//                IdUsuario = Transport.IdUsuario,
//                IdProducto = producto.IdProducto,
//                Cantidad = 1
//            };

//            // Llamada al servicio para agregar el producto al carrito
//            var resultado = await _carritoService.AgregarAlCarrito(productoDTO);

//            if (resultado == true)
//            {
//                await Application.Current.MainPage.DisplayAlert("Si!", "Agregaste el libro a tu carrito de compras.", "OK");

//            }
//            else
//            {
//                await Application.Current.MainPage.DisplayAlert("Ups!", "Esta vez no pudo ser...", "OK");
//            }
//            await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
//        }

//        [RelayCommand]
//        private async Task GoBack()
//        {
//            await Application.Current.MainPage.Navigation.PopAsync();
//        }

//        [RelayCommand]
//        private async Task EliminarProductoAsync()
//        {
//            if (producto == null)
//            {
//                await Application.Current.MainPage.DisplayAlert("Error", "No hay un producto seleccionado para eliminar.", "OK");
//                return;
//            }

//            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este producto?", "Sí", "No");

//            if (confirm)
//            {
//                try
//                {
//                    bool result = await _productoService.EliminarProductoAsync(producto.IdProducto);

//                    if (result)
//                    {
//                        await Application.Current.MainPage.DisplayAlert("Éxito", "Producto eliminado correctamente.", "OK");
//                        // Volver atrás en la navegación
//                        await GoBack();
//                    }
//                    else
//                    {
//                        await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el producto.", "OK");
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