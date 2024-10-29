using rootear.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rootear.Services;
using rootear.mvvm.Views;
using rootear.Utils;

namespace rootear.mvvm.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    ILoginService _loginService;
    [ObservableProperty] private string password = string.Empty;
    [ObservableProperty] private string nombreUsuario = string.Empty;
    [ObservableProperty] private string message = string.Empty;

    public LoginViewModel(ILoginService loginService)
    {
        Title = Constants.AppName;
#if DEBUG
        nombreUsuario = "AndresMass";
        password = "1234";

#endif
        _loginService = loginService;
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        if (!IsBusy)
        {
            IsBusy = true;

            try
            {
                if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(NombreUsuario))
                {
                    var client = new LoginService();
                    var login = await client.ValidarLogin(Password, NombreUsuario);

                    if (login != null)
                    {
                        // Configurar datos del usuario logueado
                        Transport.IdUsuario = login.IdUsuario;
                        Transport.Nombre = login.Nombre;
                        Transport.Apellido = login.Apellido;
                        Transport.UsuarioNombre = login.NombreUsuario;
                        Transport.Direccion = login.Direccion;
                        Transport.Email = login.Email;
                        Transport.Rol = login.Rol;
                        Transport.IdVehiculo = login.IdVehiculo;
                        Transport.IdSalaReserva = login.IdSalaReserva;

                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Atención", "Las credenciales ingresadas no son válidas", "Aceptar");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Atención", "Las credenciales son Obligatorias. Verifique!", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    [RelayCommand]
    private async Task NuevoUsuario()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioAgregarPage());
    }
}