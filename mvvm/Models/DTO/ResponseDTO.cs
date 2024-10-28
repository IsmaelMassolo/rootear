namespace rootear.mvvm.Models.DTO
{
    public class ResponseDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UsuarioNombre { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int IdReserva { get; set; }
        public int? IdVehiculo { get; set; }
    }
}
