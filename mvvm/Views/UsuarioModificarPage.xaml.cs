using rootear.mvvm.ViewModels;
using rootear.Services;
using rootear.Utils;

namespace rootear.mvvm.Views;

public partial class UsuarioModificarPage : ContentPage
{
	public UsuarioModificarPage()
	{
        InitializeComponent();
        UsuarioService service = new UsuarioService();
        UsuarioModificarViewModel vm = new UsuarioModificarViewModel(service);
        BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as UsuarioModificarViewModel).CargarUsuarioAsync(Transport.IdUsuario);
    }

}