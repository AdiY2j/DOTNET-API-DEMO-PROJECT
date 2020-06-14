using PlayerService.Repository;
using PlayerService.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PlayerService
{
    public class PlayerService : IPlayerService
    {
        private IRepository<Player> repository = null;
        private UnitOfWork<SampleDBEntities> unitOfWork;

        public PlayerService()
        {
            unitOfWork = new UnitOfWork<SampleDBEntities>();
            this.repository = new Repository<Player>(unitOfWork);
        }


        public bool Delete(int id)
        {

            if (repository.GetPlayer(id) != null)
            {
                repository.Delete(id);
                unitOfWork.Save();
                return true;
            }
            return false;

        }

        public Player GetPlayer(int id)
        {
            return repository.GetPlayer(id);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return repository.GetPlayers();
        }

        public bool Insert(Player player)
        {
            if (repository.GetPlayer(player.playerId) != null)
            {
                return false;
            }
            //unitOfWork.CreateTransaction();
            repository.Insert(player);
            unitOfWork.Save();
            return true;
        }

        public bool Update(Player player)
        {
            repository.Update(player);
            unitOfWork.Save();
            return true;
        }
    }
}
