using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.EntityModel
{
    public class Game
    {
        public long gameId { get; set; }
        public string gameName { get; set; }
        public DateTime createDate { get; set; }
        public bool isActive { get; set; }
        public List<GamePlayer>? players { get; set; }
        public List<Post> postGame { get; set; }
    }
}
