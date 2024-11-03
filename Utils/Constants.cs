namespace rootear.Utils;

public static class Constants
{
    //USUARIO
    public const string ObtenerUsuariosEndpoint = "http://localhost:5161/api/Usuario";
    public const string ObtenerUsuarioEndpoint = "http://localhost:5161/api/Usuario/ObtenerPorId";
    public const string CrearUsuarioEndpoint = "http://localhost:5161/api/Usuario/Crear";
    public const string GuardarImagenUsuarioEndpoint = "http://localhost:5161/api/Usuario/GuardarImagen";
    public const string DeshabilitarUsuarioEndpoint = "http://localhost:5161/api/Usuario/Deshabilitar";
    public const string ModificarUsuarioEndpoint = "http://localhost:5161/api/Usuario/Modificar";
    public const string ValidarCredencialEndpoint = "http://localhost:5161/api/Usuario/ValidarCredencial";
    //LUGAR
    public const string ObtenerLugaresEndpoint = "http://localhost:5161/api/Lugar";
    //VIAJE
    public const string ObtenerViajesEndpoint = "http://localhost:5161/api/Viaje";
    public const string ObtenerViajeEndpoint = "http://localhost:5161/api/Viaje/ObtenerPorId";
    public const string CrearViajeEndpoint = "http://localhost:5161/api/Viaje/Crear";
    public const string EliminarViajeEndpoint = "http://localhost:5161/api/Viaje";
    //RESERVA
    public const string AgregarEnReservaEndpoint = "http://localhost:5161/api/DetalleReserva/Agregar";
    public const string EliminarDetalleReservaEndpoint = "http://localhost:5161/api/DetalleReserva/Eliminar";
    public const string DetalleReservaEndpoint = "http://localhost:5161/api/DetalleReserva/Reserva";

    public const string DetalleReservaAgregarEndpoint = "http://localhost:5161/api/DetalleReserva/Agregar";


    public static string AppName = "rootear";

}
