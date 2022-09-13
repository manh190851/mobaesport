using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.MessageModel
{
    public interface IManageMessage
    {
        Task<long> Create(MessageCreateModel model);

        Task<long> Delete(Guid userId, long messageId);
    }
}
