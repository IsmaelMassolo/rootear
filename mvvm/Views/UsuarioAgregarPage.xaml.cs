using rootear.Services;
using rootear.mvvm.ViewModels;

namespace BookApp.mvvm.Views;

public partial class UsuarioAgregarPage : ContentPage
{
    public UsuarioAgregarPage()
    {
        InitializeComponent();
        BindingContext = new UsuarioAgregarViewModel(new UsuarioService(), new LugarService());
    }
}