
/* Cambio no fusionado mediante combinación del proyecto 'rootear (net8.0-ios)'
Antes:
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
Después:
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
*/

/* Cambio no fusionado mediante combinación del proyecto 'rootear (net8.0-android)'
Antes:
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
Después:
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
*/

/* Cambio no fusionado mediante combinación del proyecto 'rootear (net8.0-maccatalyst)'
Antes:
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
Después:
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
*/
using System.ComponentModel.DataAnnotations;

namespace rootear.mvvm.Models.DTO
{
    public class ViajeDTO
    {
        public int IdOrigen { get; set; }

        public int IdDestino { get; set; }

        public int IdUsuarioCreador { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }

        public DateTime? FechaArribo { get; set; }

        [Required]
        public int CantButacas { get; set; }

        [Required]
        public DateTime ActivoDesde { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = true;
    }
}
