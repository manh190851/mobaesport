using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.EntityModel
{
    public class GamePlayer
    {
        public Guid playerId { get; set; }
        public AppUser player { get; set; }
        public long gameId { get; set; }
        public Game game { get; set; }
    }
}
