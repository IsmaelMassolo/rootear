using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;

namespace rootear.Services;

public interface IHistorialService
{
    Task<IEnumerable<Viaje>> GetHistorialPorId();
}
