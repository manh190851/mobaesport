using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.MessageModel
{
    public interface IManageMessage
    {
        Task<int> Create(MessageCreateModel model, long chatboxId);

        Task<int> Delete(Guid userId, long messageId);
    }
}
