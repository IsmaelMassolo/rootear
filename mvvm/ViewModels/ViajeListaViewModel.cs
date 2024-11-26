﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Views;
using rootear.Services;
using rootear.Utils;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels

{
    public partial class ViajeListaViewModel : BaseViewModel
    {
        public ObservableCollection<Viaje> Viajes { get; } = new();
        public ObservableCollection<Viaje> ViajesFiltrados { get; } = new();
        [ObservableProperty] bool isRefreshing;
        [ObservableProperty] Viaje viajeSeleccionado;
        [ObservableProperty] string searchText;
        IViajeService _viajeService;
        [ObservableProperty] private string esVisible = Transport.Rol;

        public ViajeListaViewModel(IViajeService viajeService)
        {
            _viajeService = viajeService;
            Viajes.CollectionChanged += (s, e) => FiltrarViajes();
            ViajesFiltrados.CollectionChanged += (s, e) => OnPropertyChanged(nameof(ViajesFiltrados));
        }

        [RelayCommand]
        private async Task GetViajesAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var viajes = await _viajeService.GetViajes();
                    if (viajes != null)
                    {
                        Viajes.Clear();
                        foreach (var viaje in viajes)
                            Viajes.Add(viaje);
                        FiltrarViajes();
                    }
                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        [RelayCommand]
        private async Task GoToDetail()
        {
            if (viajeSeleccionado == null) { return; }
            await Application.Current.MainPage.Navigation.PushAsync(new ViajeDetallePage(viajeSeleccionado), true);
        }

        [RelayCommand]
        private void Buscar()
        {
            FiltrarViajes();
        }

        private void FiltrarViajes()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                ViajesFiltrados.Clear();
                foreach (var viaje in Viajes)
                    ViajesFiltrados.Add(viaje);
            }
            else
            {
                var filtrado = Viajes.Where(v =>
                v.Destino.Ciudad.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                v.Origen.Ciudad.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
                ViajesFiltrados.Clear();
                foreach (var viaje in filtrado)
                    ViajesFiltrados.Add(viaje);
            }
        }

        [RelayCommand]
        private async Task NuevoViaje()
        {
            if (Transport.Rol == "Acompañante")
            {
                await Application.Current.MainPage.DisplayAlert("Ey!", "Tienes vehículo? Apuntate como conductor!", "OK");
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViajeAgregarPage());
            }
        }

        [RelayCommand]
        private async Task GoToMainPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}