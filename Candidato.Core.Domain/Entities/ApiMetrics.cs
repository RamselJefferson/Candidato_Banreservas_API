using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Domain.Entities
{
    public class ApiMetrics
    {
        public string HttpMethod { get; set; }
        public string Result { get; set; }
        public int Count { get; set; }
        public double AverageResponseTime { get; set; }
        public double MinResponseTime { get; set; }
        public double MaxResponseTime { get; set; }
        public double TPM { get; set; } 
    }

    public class ApiRequestLog
    {
        public int Id { get; set; }
        public string Endpoint { get; set; }
        public string HttpMethod { get; set; }
        public DateTime RequestTime { get; set; }
        public double ResponseTime { get; set; } 
        public string Result { get; set; } 
    }

}

