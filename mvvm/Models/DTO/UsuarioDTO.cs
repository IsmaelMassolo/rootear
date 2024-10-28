using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace rootear.mvvm.Models.DTO
{
    public class UsuarioDTO
    {
        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Apellido { get; set; }

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
        public DateTime FechaNac { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Dni { get; set; }

        [Required]
        public int Edad { get; set; }

        [MaxLength(10)]
        public string? Genero { get; set; }

        [MaxLength(50)]
        public string? Rol { get; set; }

        public int IdLugar { get; set; }

        public int? IdVehiculo { get; set; }

        [MaxLength(255)]
        public string? RutaImagen { get; set; }

        public IFormFile? Imagen { get; set; } = null;
    }
}
