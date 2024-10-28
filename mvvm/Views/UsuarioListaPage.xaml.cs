using rootear.Services;
using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views;

public partial class UsuarioListaPage : ContentPage
{
    public UsuarioListaPage()
    {
        UsuarioService service = new UsuarioService();
        UsuarioListaViewModel vm = new UsuarioListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as UsuarioListaViewModel;

        if (vm != null)
        {
            await vm.GetUsuariosCommand.ExecuteAsync(null);
        }
    }

}