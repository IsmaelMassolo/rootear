using rootear.mvvm.Models;

namespace rootear.Services;

public interface IHistorialService
{
    Task<IEnumerable<Viaje>> GetHistorialPorId();
}
