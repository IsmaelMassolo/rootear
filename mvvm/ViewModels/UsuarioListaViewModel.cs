using rootear.mvvm.Models;
using rootear.Services;
using rootear.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using rootear.Utils;

namespace rootear.mvvm.ViewModels
{
    public partial class UsuarioListaViewModel : BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; } = new();

        [ObservableProperty] private string esVisible = Transport.Rol;

        [ObservableProperty] bool isRefreshing;

        [ObservableProperty] Usuario usuarioSeleccionado;

        IUsuarioService _usuarioService;

        public UsuarioListaViewModel(IUsuarioService usuarioService)
        {
            Title = "Lista de Usuarios";
            _usuarioService = usuarioService;
        }

        [RelayCommand]
        private async Task GetUsuariosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    // consultamos lista de Usuarios
                    var usuarios = await _usuarioService.GetUsersAsync();

                    if (usuarios != null)
                    {
                        if (Usuarios.Count != 0)
                            Usuarios.Clear();

                        foreach (var usuario in usuarios)
                            Usuarios.Add(usuario);
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
            if (usuarioSeleccionado == null)
            {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioDetallePage(usuarioSeleccionado), true);
        }

        [RelayCommand]
        private async Task GoToMainPage()
        {
            // Navegar a MainPage
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

    }
}
