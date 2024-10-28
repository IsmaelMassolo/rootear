//using rootear.mvvm.Models;
//using rootear.mvvm.Services;
//using rootear.Utils;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Collections.ObjectModel;

//namespace rootear.mvvm.ViewModels;

//public partial class ProductoAgregarViewModel : BaseViewModel
//{
//    [ObservableProperty] private string titulo;
//    [ObservableProperty] private string sinopsis;
//    [ObservableProperty] private int stock;
//    [ObservableProperty] private float precio;
//    [ObservableProperty] private string autor;
//    [ObservableProperty] private int anioEdicion;
//    [ObservableProperty] private string editorial;
//    [ObservableProperty] private string idioma;
//    [ObservableProperty] private int cantPaginas;
//    [ObservableProperty] private string estado;
//    [ObservableProperty] private string isbn;
//    [ObservableProperty] private string formato;
//    [ObservableProperty] private int cuotas;
//    [ObservableProperty] private int costoEnvio;
//    [ObservableProperty] private string envio;
//    [ObservableProperty] private bool habilitado;
//    [ObservableProperty] private string rutaImagen;
//    [ObservableProperty] private string rutaImagenLocal;
//    IViajeService _productoService;
//    [ObservableProperty] List<string> listaGenero;
//    [ObservableProperty] private string generoSeleccionado;

//    public ProductoAgregarViewModel(IViajeService productoService)
//    {
//        Title = Constants.AppName;
//        listaGenero = GetGenerosValues();
//        _productoService = productoService;
//    }


//    [RelayCommand]
//    private async Task Cancelar()
//    {
//        await Application.Current.MainPage.Navigation.PopAsync();
//    }

//    [RelayCommand]
//    private async Task GrabarProducto()
//    {
//        var registro = new ProductoDTO
//        {
//            Titulo = this.titulo,
//            Autor = this.autor,
//            AnioEdicion = this.anioEdicion,
//            Editorial = this.editorial,
//            Sinopsis = this.sinopsis,
//            Idioma = this.idioma,
//            CantPaginas = this.cantPaginas,
//            ISBN = this.isbn,
//            Estado = this.estado,
//            Stock = this.stock,
//            Formato = this.formato,
//            Precio = Convert.ToDecimal(this.Precio),
//            Cuotas = this.cuotas,
//            Envio = this.envio,
//            CostoEnvio = this.costoEnvio,
//            Habilitado = this.habilitado,
//            Genero = this.generoSeleccionado,
//            RutaImagen = "http://localhost:5140/ImagenesProductos/" + this.titulo + ".png",
//            RutaImagenLocal = this.rutaImagenLocal
//        };

//        try
//        {
//            await _productoService.AgregarProducto(registro);

//            if (!string.IsNullOrEmpty(RutaImagenLocal))
//            {
//                await _productoService.SubirImagen(registro);
//            }

//            await Application.Current.MainPage.DisplayAlert("Exito", "Nuevo Producto grabado.", "Aceptar");
//        }
//        catch (Exception)
//        {
//            await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
//        }
//        await Application.Current.MainPage.Navigation.PopAsync();
//    }


//    [RelayCommand]
//    private async Task SeleccionarImagen()
//    {
//        try
//        {
//            var resultado = await FilePicker.PickAsync(new PickOptions
//            {
//                PickerTitle = "Selecciona una imagen",
//                FileTypes = FilePickerFileType.Images 
//            });

//            if (resultado != null)
//            {
//                RutaImagenLocal = resultado.FullPath;
//            }
//        }
//        catch (Exception ex)
//        {
//            await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo seleccionar la imagen: {ex.Message}", "Aceptar");
//        }
//    }

//    private List<string> GetGenerosValues()
//    {
//        var generosValues = new List<string>
//    {
//        "Fantasía",
//        "Ciencia ficción",
//        "Terror",
//        "Aventura",
//        "Biografía",
//        "Historia",
//        "Autoyuda"
//    };

//        return generosValues;
//    }
//}