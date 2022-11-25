using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.GameModel
{
    public class ManageGame : IManageGame
    {
        private ESportDbContext _db;

        public ManageGame(ESportDbContext db)
        {
            this._db = db;
        }

        public async Task<long> ChangeActive(long gameId, bool isActive)
        {
            var game = await _db.Games.FindAsync(gameId);
            game.isActive= isActive;
            return await _db.SaveChangesAsync();
        }

        public async Task<long> Create(GameCreateModel model)
        {
            var game = new Game()
            {
                gameName = model.Name,
                createDate = model.Created,
                isActive = model.IsActive,
            };
            _db.Games.Add(game);
            return await _db.SaveChangesAsync();
        }

        public async Task<long> Delete(long gameId)
        {
            var game = _db.Games.Find(gameId);
            _db.Games.Remove(game);
            return await _db.SaveChangesAsync();

        }

        public async Task<GameViewModel> GetGameById(long gameId)
        {
            var games = _db.Games.Find(gameId);

            return new GameViewModel
            {
                gameId = games.gameId,
                gameName = games.gameName,
                isActive = games.isActive,
                gameTime = games.createDate
            };

        }

        public async Task<long> Update(GameViewModel model)
        {
            var games = await _db.Games.FindAsync(model.gameId);
            games.gameName = model.gameName;
            games.createDate = model.gameTime;
            games.isActive = model.isActive;

            return await _db.SaveChangesAsync();
        }

        public async Task<List<AppUser>> GetPlayers(long gameId)
        {
            var players = _db.GamePlayers.ToList().Where(i => i.gameId == gameId);

            List<AppUser> result = new List<AppUser>();
            foreach(var player in players)
            {
                var user = await _db.Users.FindAsync(player.playerId);
                result.Add(user);
            }
            return result;
        }
    }
}
