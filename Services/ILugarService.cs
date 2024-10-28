using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;

namespace rootear.Services
{
    public interface ILugarService
    {
        Task<IEnumerable<Lugar>> ObtenerLugaresAsync();
    }
}
