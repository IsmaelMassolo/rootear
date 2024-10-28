using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.Services;
using rootear.Utils;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels;

public partial class UsuarioAgregarViewModel : BaseViewModel
{
    [ObservableProperty] private string nombre;
    [ObservableProperty] private string apellido;
    [ObservableProperty] private string usuarioNombre;
    [ObservableProperty] private string email;
    [ObservableProperty] private string contrasena;
    [ObservableProperty] private string celular;
    [ObservableProperty] private DateTime fechaNac;
    [ObservableProperty] private string dni;
    [ObservableProperty] private string ciudad;
    [ObservableProperty] private string provincia;
    [ObservableProperty] private string genero;
    [ObservableProperty] private string rol;
    [ObservableProperty] private string rutaImagen;
    [ObservableProperty] private Lugar lugarSeleccionado;
    [ObservableProperty] private string lugarBusqueda;
    [ObservableProperty] private ObservableCollection<Lugar> lugaresFiltrados = new();
    [ObservableProperty] private List<TipoDeUsuario> listaRol;
    [ObservableProperty] private TipoDeUsuario rolSeleccionado;
    [ObservableProperty] private List<GeneroDeUsuario> listaGenero;
    [ObservableProperty] private GeneroDeUsuario generoSeleccionado;
    private readonly IUsuarioService _usuarioService;
    private readonly ILugarService _lugarService;

    public UsuarioAgregarViewModel(IUsuarioService usuarioService, ILugarService lugarService)
    {
        Title = Constants.AppName;
        _usuarioService = usuarioService;
        _lugarService = lugarService;
        listaRol = GetRolValues();
        listaGenero = GetGeneroValues();
        CargarLugaresCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Cancelar()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task AgregarNuevoUsuario()
    {

        var registro = new UsuarioDTO
        {
            Nombre = nombre,
            Apellido = apellido,
            UsuarioNombre = usuarioNombre,
            Email = email,
            Contrasena = contrasena,
            Celular = celular,
            FechaNac = fechaNac,
            Dni = dni,
            Genero = GeneroSeleccionado?.Value,
            Rol = RolSeleccionado?.Value,
            IdLugar = LugarSeleccionado?.IdLugar ?? 0,
            RutaImagen = rutaImagen/*"http://localhost:5161/Imagenes/Usuarios/" + this.usuarioNombre + ".png",*/
        };

        try
        {
            await _usuarioService.AgregarUsuario(registro);
            if (!string.IsNullOrEmpty(RutaImagen))
            {
                await _usuarioService.SubirImagen(registro);
            }
            await Application.Current.MainPage.DisplayAlert("Éxito", "Hola "+nombre+"! ahora puedes disfrutar de viajes compartidos rootear!", "Aceptar");
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Error al grabar.", "Aceptar");
        }

        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task CargarLugares()
    {
        var lugares = await _lugarService.ObtenerLugaresAsync();
        LugaresFiltrados = new ObservableCollection<Lugar>(lugares);
        FiltrarLugares();
    }

    private void FiltrarLugares()
    {
        if (string.IsNullOrWhiteSpace(LugarBusqueda))
        {
            // Mostrar todos los lugares si la búsqueda está vacía
            LugaresFiltrados = new ObservableCollection<Lugar>(LugaresFiltrados);
        }
        else
        {
            var filtro = LugarBusqueda.ToLower();
            var lugaresFiltrados = LugaresFiltrados
                .Where(l => l.Ciudad.ToLower().Contains(filtro) || l.Provincia.ToLower().Contains(filtro))
                .ToList();

            LugaresFiltrados = new ObservableCollection<Lugar>(lugaresFiltrados);
        }
    }

    private List<TipoDeUsuario> GetRolValues()
    {
        var RolValues = new List<TipoDeUsuario>()
        {
            new TipoDeUsuario { Key = 1, Value = "Acompañante" },
            new TipoDeUsuario { Key = 2, Value = "Conductor" },
            //new TipoDeUsuario { Key = 3, Value = "Administrador" }
        };
        return RolValues;
    }

    private List<GeneroDeUsuario> GetGeneroValues()
    {
        var GeneroValues = new List<GeneroDeUsuario>()
        {
            new GeneroDeUsuario { Key = 1, Value = "Mujer" },
            new GeneroDeUsuario { Key = 2, Value = "Hombre" },
            new GeneroDeUsuario { Key = 3, Value = "Binario" },
            new GeneroDeUsuario { Key = 3, Value = "Prefiero no decirlo" }
        };
        return GeneroValues;
    }

    [RelayCommand]
    private async Task SeleccionarImagen()
    {
        try
        {
            var resultado = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona una imagen",
                FileTypes = FilePickerFileType.Images
            });

            if (resultado != null)
            {
                RutaImagen = resultado.FullPath;
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo seleccionar la imagen: {ex.Message}", "Aceptar");
        }
    }
}