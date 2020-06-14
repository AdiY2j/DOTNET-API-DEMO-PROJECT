using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PlayerService
{
    [ServiceContract]
    public interface IPlayerService
    {
        [OperationContract]
        IEnumerable<Player> GetPlayers();

        [OperationContract]
        Player GetPlayer(int id);

        [OperationContract]
        bool Insert(Player player);

        [OperationContract]
        bool Update(Player player);

        [OperationContract]
        bool Delete(int id);
    }

}
