using rootear.mvvm.ViewModels;
using rootear.mvvm.Views;
using CommunityToolkit.Mvvm.Input;

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

        //[RelayCommand]
        //public async Task GoToCarrito()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new CarritoPage());
        //}

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
