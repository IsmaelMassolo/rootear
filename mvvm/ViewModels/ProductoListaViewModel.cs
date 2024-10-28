//using rootear.mvvm.Models;
//using rootear.mvvm.Services;
//using rootear.mvvm.Views;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Collections.ObjectModel;

//namespace rootear.mvvm.ViewModels

//{
//    public partial class ProductoListaViewModel : BaseViewModel
//    {
//        public ObservableCollection<Producto> Productos { get; } = new();
//        public ObservableCollection<Producto> ProductosFiltrados { get; } = new();
//        [ObservableProperty] bool isRefreshing;
//        [ObservableProperty] Producto productoSeleccionado;
//        [ObservableProperty] string searchText;
//        IViajeService _productoService;
//        [ObservableProperty] private int esVisible = Transport.RolUsuario;

//        public ProductoListaViewModel(IViajeService productoService)
//        {
//            Title = "Nuestros libros ;)";
//            _productoService = productoService;
//            Productos.CollectionChanged += (s, e) => FiltrarProductos();
//            ProductosFiltrados.CollectionChanged += (s, e) => OnPropertyChanged(nameof(ProductosFiltrados));
//        }

//        [RelayCommand]
//        private async Task GetProductosAsync()
//        {
//            if (!IsBusy)
//            {
//                try
//                {
//                    IsBusy = true;
//                    var productos = await _productoService.GetProductos();
//                    if (productos != null)
//                    {
//                        Productos.Clear();
//                        foreach (var producto in productos)
//                            Productos.Add(producto);
//                        FiltrarProductos();
//                    }
//                    IsBusy = false;
//                }
//                catch (Exception ex)
//                {
//                    await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
//                }
//                finally
//                {
//                    IsBusy = false;
//                }
//            }
//        }

//        [RelayCommand]
//        private async Task GoToDetail()
//        {
//            if (productoSeleccionado == null)
//            {
//                return;
//            }
//            await Application.Current.MainPage.Navigation.PushAsync(new ProductoDetallePage(productoSeleccionado), true);
//        }

//        [RelayCommand]
//        private void Buscar()
//        {
//            FiltrarProductos();
//        }

//        private void FiltrarProductos()
//        {
//            if (string.IsNullOrEmpty(SearchText))
//            {
//                ProductosFiltrados.Clear();
//                foreach (var producto in Productos)
//                    ProductosFiltrados.Add(producto);
//            }
//            else
//            {
//                var filtrado = Productos.Where(p => p.Titulo.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
//                ProductosFiltrados.Clear();
//                foreach (var producto in filtrado)
//                    ProductosFiltrados.Add(producto);
//            }
//        }

//        [RelayCommand]
//        private async Task NuevoProducto()
//        {
//            await Application.Current.MainPage.Navigation.PushAsync(new ProductoAgregarPage());
//        }

//        [RelayCommand]
//        private async Task GoToMainPage()
//        {
//            // Navegar a MainPage
//            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
//        }
//    }
//}