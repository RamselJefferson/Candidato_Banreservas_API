using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;

using System.Text;

using System.Threading.Tasks;

namespace Candidato.Core.Domain.Entities
{
    public class Candidatos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PuestoAplicado { get; set; }
        public DateTime FechaAplicacionPuesto { get; set; }

    }
}
