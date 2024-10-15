using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Request
{
    public class CandidatoRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellidos { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string PuestoAplicado { get; set; }

       
    }
    public class UpdateCandidatoRequest : CandidatoRequest
    {
        public int Id { get; set; }

    }
}
