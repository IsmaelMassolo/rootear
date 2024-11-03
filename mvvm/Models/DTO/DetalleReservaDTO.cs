using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rootear.mvvm.Models.DTO
{
    public class DetalleReservaDTO
    {
        public int IdSalaReserva { get; set; }

        public int IdViaje { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.Now;
    }
}
