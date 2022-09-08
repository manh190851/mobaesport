using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ChatBoxModel
{
    public interface IManageChatBox
    {
        Task<int> Create(ChatBoxCreateModel model);

        Task<int> Delete(long chatboxId);
    }
}
