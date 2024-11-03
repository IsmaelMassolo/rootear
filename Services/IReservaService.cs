using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;

namespace rootear.Services;

public interface IReservaService
{

    Task<IEnumerable<Viaje>> GetDetalleReservaPorId();
    Task<bool> AgregarA_DetalleReserva(DetalleReservaDTO _nuevaReservaDTO);
    Task<bool> EliminarViajeAsync(DetalleReservaDTO dto);
}
