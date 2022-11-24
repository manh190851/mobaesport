using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public class FriendViewModel
    {
        public Guid Id { get; set; }

        public AppUser Friend { get; set; }
    }
}
