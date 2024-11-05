using rootear.mvvm.ViewModels;
using rootear.mvvm.Views;
using CommunityToolkit.Mvvm.Input;
using rootear.Utils;

namespace rootear.mvvm.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = "rootear";
        }

        [RelayCommand]
        public async Task GoToViajeLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViajeListaPage());
        }

        [RelayCommand]
        public async Task GoToMisViajes()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HistorialPage());
        }

        [RelayCommand]
        public async Task GoToMisReservas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ReservaPage());
        }

        [RelayCommand]
        public async Task GoToCrearViaje()
        {
            if (Transport.Rol == "Acompañante")
            {
                await Application.Current.MainPage.DisplayAlert("Ups!", "No puedes planear viaje al menos que te apuntes como Conductor", "OK");
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViajeAgregarPage());
            }
        }

        [RelayCommand]
        public async Task GoToUsuarioLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
        }

        [RelayCommand]
        public async Task GoToPerfilUsuario()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioModificarPage());
        }

        [RelayCommand]
        public async Task GoToMapas()
        {
            await Application.Current.MainPage.DisplayAlert("Ups!", "Para ver mapas personalizados hazte rooter premium!", "OK");
        }


        [RelayCommand]
        public async Task GoToAcerca()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
        }

        [RelayCommand]
        public async Task Exit()
        {
            bool confirmExit = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar", "Cancelar");

            if (confirmExit)
            {

                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
