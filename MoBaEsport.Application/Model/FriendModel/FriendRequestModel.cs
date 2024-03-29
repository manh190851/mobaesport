﻿using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public class FriendRequestModel
    {
        public long friendId { get; set; }
        public Guid RequestId { get; set; } //User who want to make friend with
        public AppUser Requester { get; set; }
        public DateTime Created { get; set; }
    }
}
