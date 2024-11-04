using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.Services;
using rootear.Utils;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels;
public partial class ViajeAgregarViewModel : BaseViewModel
{

    [ObservableProperty] private int idOrigen;
    [ObservableProperty] private int idDestino;
    [ObservableProperty] private DateTime fechaSalida = DateTime.Now;
    [ObservableProperty] private DateTime fechaArribo = DateTime.Now;
    [ObservableProperty] private TimeSpan horaSalida = DateTime.Now.TimeOfDay;
    [ObservableProperty] private TimeSpan horaLlegada = DateTime.Now.TimeOfDay;
    [ObservableProperty] private string cantButacas = "1";
    [ObservableProperty] private Lugar? origenSeleccionado;
    [ObservableProperty] private Lugar? destinoSeleccionado;
    [ObservableProperty] private ObservableCollection<Lugar> lugaresFiltrados = new();
    [ObservableProperty] private string? lugarBusqueda;
    private readonly IViajeService _viajeService;
    private readonly ILugarService _lugarService;

    public ViajeAgregarViewModel(IViajeService viajeService, ILugarService lugarService)
    {
        Title = Constants.AppName;
        _viajeService = viajeService;
        _lugarService = lugarService;
        CargarLugaresCommand.Execute(null);
    }


    [RelayCommand]
    private async Task Cancelar()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task GrabarViaje()
    {
        var registro = new ViajeDTO
        {
            IdOrigen = OrigenSeleccionado?.IdLugar ?? 0,
            IdDestino = DestinoSeleccionado?.IdLugar ?? 0,
            IdUsuarioCreador = Transport.IdUsuario,
            FechaSalida = FechaSalida.Date + HoraSalida,
            FechaArribo = FechaArribo.Date + HoraLlegada,
            CantButacas = int.Parse(this.CantButacas),
            ActivoDesde = DateTime.Now,
            Estado = true
        };

        try
        {
            await _viajeService.CrearViaje(registro);
            await Application.Current.MainPage.DisplayAlert("Exito", "Nuevo Viaje grabado.", "Aceptar");
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
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
}