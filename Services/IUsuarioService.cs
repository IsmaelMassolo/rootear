using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;


namespace rootear.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetUsersAsync();
    Task<bool> AgregarUsuario(UsuarioDTO _usuario);
    Task<bool> SubirImagen(UsuarioDTO registro);
    Task<bool> DeshabilitarUsuarioAsync(Usuario usuario);
    Task<bool> ActualizarUsuarioAsync(Usuario usuario);
    Task<Usuario> GetPorId(int idUsuario);
}
