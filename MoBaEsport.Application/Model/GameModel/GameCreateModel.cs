using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.GameModel
{
    public class GameCreateModel
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
    }
}
