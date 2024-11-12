using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rootear.mvvm.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        public int IdUsuario { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = true;

        public ICollection<DetalleReserva>? DetallesReservas { get; set; } // Una reserva puede tener muchos viajes pendientes

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}