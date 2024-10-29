using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;

namespace rootear.mvvm.Services;

public interface IViajeService
{
    Task<IEnumerable<Viaje>> GetViajes();
    Task<Viaje> GetViajePorId(int id);
    Task<bool> CrearViaje(ViajeDTO _viaje);
    Task<bool> EliminarViajeAsync(int id);
}
