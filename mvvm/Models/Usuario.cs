using rootear.mvvm.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rootear.mvvm.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Apellido { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string? UsuarioNombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Contrasena { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Celular { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Dni { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public DateTime FechaNac { get; set; }

        [MaxLength(10)]
        public string? Genero { get; set; }


        [MaxLength(50)]
        public string? Rol { get; set; }

        [MaxLength(255)]
        public string? RutaImagen { get; set; }

        [Required]
        public DateTime ActivoDesde { get; set; } = DateTime.Now;

        // Relación uno a uno con Lugar
        [ForeignKey("IdLugar")]
        public Lugar? Lugar { get; set; }

        // Relación uno a uno con Vehiculo
        [ForeignKey("IdVehiculo")]
        public Vehiculo? Vehiculo { get; set; }

        // Relación uno a uno con Reserva
        public Reserva? Reserva { get; set; }

        public int IdLugar { get; set; } // Relación uno a uno
        public int? IdVehiculo { get; set; } // Relación uno a uno opcional
    }
}

