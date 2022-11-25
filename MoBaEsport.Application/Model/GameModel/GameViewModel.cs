using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.GameModel
{
    public class GameViewModel
    {
        public long gameId { get; set; }
        public string gameName { get; set; }
        public DateTime gameTime { get; set; }
        public bool isActive { get; set; }
    }
}
