using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostReportModel
    {
        public long PostId { get; set; }
        public string? Reason { get; set; }
        public DateTime reportDate { get; set; }
    }
}
