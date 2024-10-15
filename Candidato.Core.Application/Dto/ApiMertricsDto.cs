using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Dto
{
    public class ApiMertricsDto
    {
        public int CantidadPeticion { get; set; }
        public string EndPoint { get; set; }
        public string? HttpMethod { get; set; }
        public int PromedioRespuestaMs { get; set; }
        public int Result { get; set; }
        public int TransaccionesPorMinuto { get; set; }


    }


}
