using rootear.mvvm.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rootear.mvvm.Models
{
    public class DetalleReserva
    {
        [Key]
        public int idDetalleReserva { get; set; }

        public int IdReserva { get; set; }

        public int IdViaje { get; set; }

        [Required]
        public DateTime FechaAgregado { get; set; } = DateTime.Now;

        [ForeignKey("IdReserva")]
        public Reserva? Reserva { get; set; }

        [ForeignKey("IdViaje")]
        public Viaje Viaje { get; set; }
    }
}
