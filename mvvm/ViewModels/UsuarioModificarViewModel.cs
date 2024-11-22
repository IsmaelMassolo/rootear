﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.mvvm.Models;
using rootear.mvvm.Views;
using rootear.Services;
using System.Collections.ObjectModel;

namespace rootear.mvvm.ViewModels;

public partial class UsuarioModificarViewModel : BaseViewModel
{
    IUsuarioService _usuarioService;
    [ObservableProperty] Usuario usuario;
    public ObservableCollection<string> Roles { get; set; }

    public UsuarioModificarViewModel(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
        Title = "Perfil de Usuario";

        Roles = new ObservableCollection<string>
        {
            "Conductor",
            "Acompañante",
            //"Administrador"
        };
    }

    [RelayCommand]
    private async Task Cancelar()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task Grabar()
    {
        await Application.Current.MainPage.DisplayAlert("Usuario", "Usuario modificado", "Aceptar");
    }

    public async Task CargarUsuarioAsync(int idUsuario)
    {
        try
        {
            Usuario = await _usuarioService.GetPorId(idUsuario);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Error al cargar usuario: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task GuardarCambiosAsync()
    {
        if (usuario == null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No hay un usuario para guardar los cambios.", "OK");
            return;
        }

        try
        {
            bool result = await _usuarioService.ActualizarUsuarioAsync(usuario);
            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario actualizado correctamente. Accede nuevamente con tus credenciales para seguir rooteando", "OK");
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar el usuario.", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
}