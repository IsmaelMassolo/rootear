using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;

namespace rootear.Services;

public interface IReservaService
{
    Task<Reserva> GetReservasPorId(int id);

    Task<IEnumerable<DetalleReserva>> GetDetalleReservaPorId(int id);
    Task<bool> AgregarA_DetalleReserva(DetalleReservaDTO _nuevaReservaDTO);
    //Task<bool> ModificarCarro(int idUsuario, Reserva reserva);
    //Task<bool> EliminarViajeAsync(EliminarDetalleReservaDTO dto);

}
