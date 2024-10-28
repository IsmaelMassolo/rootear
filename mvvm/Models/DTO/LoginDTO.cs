using System.ComponentModel.DataAnnotations;

namespace rootear.mvvm.Models.DTO
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; }
        public int? IdVehiculo { get; set; } = 0;
        public int IdSalaReserva { get; set; }
        public string? MensajeError { get; set; }
    }
}
