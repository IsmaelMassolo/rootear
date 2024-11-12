using rootear.mvvm.Models;
using rootear.mvvm.ViewModels;
using rootear.Services;

namespace rootear.mvvm.Views;

public partial class UsuarioDetallePage : ContentPage
{
    public UsuarioDetallePage(Usuario param)
    {
        InitializeComponent();
        UsuarioService usuario = new UsuarioService();
        //CarritoService service = new CarritoService();
        UsuarioDetalleViewModel vm = new UsuarioDetalleViewModel(param, usuario);
        this.BindingContext = vm;
        vm.Usuario = param;
    }
}