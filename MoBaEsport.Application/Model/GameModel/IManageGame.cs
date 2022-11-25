using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.GameModel
{
    public interface IManageGame
    {
        Task<long> Create(GameCreateModel model);
        Task<long> Update(GameViewModel model);
        Task<GameViewModel> GetGameById(long gameId);
        Task<long> Delete(long gameId);
        Task<long> ChangeActive(long gameId, bool isActive);
    }
}
