using rootear.mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.Services;
using rootear.Utils;

namespace rootear.mvvm.ViewModels
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {
        [ObservableProperty] private Usuario usuario;
        IUsuarioService _usuarioService;
        [ObservableProperty] private string esVisible = Transport.Rol;

        public UsuarioDetalleViewModel(Usuario usuario, IUsuarioService usuarioService)
        {
            Title = "Detalle de Usuario";
            Usuario = usuario;
            _usuarioService = usuarioService;
        }


        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task DeshabilitarUsuarioAsync()
        {
            if (usuario == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay un usuario seleccionado para eliminar.", "OK");
                return;
            }

            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de que deseas deshabilitar este usuario?", "Sí", "No");

            if (confirm)
            {
                try
                {
                    bool result = await _usuarioService.DeshabilitarUsuarioAsync(usuario);

                    if (result)
                    {
                        await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario Desctivado correctamente.", "OK");
                        await GoBack();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "No se pudo deshabilitar al usuario.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
                }
            }
        }

    }
}