﻿namespace rootear.mvvm.Models.DTO
{
    public class DetalleReservaDTO
    {
        public int IdSalaReserva { get; set; }

        public int IdViaje { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.Now;

        public int IdUsuario { get; set; }
    }
}
