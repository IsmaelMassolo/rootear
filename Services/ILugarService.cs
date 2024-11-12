using rootear.mvvm.Models;

namespace rootear.Services
{
    public interface ILugarService
    {
        Task<IEnumerable<Lugar>> ObtenerLugaresAsync();
    }
}
