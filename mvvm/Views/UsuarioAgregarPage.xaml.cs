using rootear.mvvm.ViewModels;
using rootear.Services;

namespace rootear.mvvm.Views;

public partial class UsuarioAgregarPage : ContentPage
{
    public UsuarioAgregarPage()
    {
        InitializeComponent();
        BindingContext = new UsuarioAgregarViewModel(new UsuarioService(), new LugarService());
    }
}