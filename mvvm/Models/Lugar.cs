using System.ComponentModel.DataAnnotations;

namespace rootear.mvvm.Models
{
    public class Lugar
    {
        [Key]
        public int IdLugar { get; set; }

        [Required]
        [StringLength(100)]
        public string? Ciudad { get; set; }

        [Required]
        [StringLength(100)]
        public string? Provincia { get; set; }

        [Required]
        [StringLength(100)]
        public string? Pais { get; set; }

        [Required]
        [StringLength(10)]
        public string? CodPostal { get; set; }

        // Relación 1 a muchos con Viaje (idOrigen)
        public ICollection<Viaje>? ViajesOrigen { get; set; }

        // Relación 1 a muchos con Viaje (idDestino)
        public ICollection<Viaje>? ViajesDestino { get; set; }
        // Relación uno a uno con Usuario
        public Usuario? Usuario { get; set; }
    }
}