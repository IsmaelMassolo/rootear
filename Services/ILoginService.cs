using rootear.mvvm.Models.DTO;

namespace rootear.Services
{
    public interface ILoginService
    {
        Task<LoginDTO> ValidarLogin(string _password, string _usuarioNombre);
    }
}
