using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.EntityModel
{
    public class PostFile
    {
        public long Id { get; set; }

        public string FilePath { get; set; }

        public long PostId { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreate { get; set; }

        public int Size { get; set; }

        public Post Post { get; set; }
    }
}
