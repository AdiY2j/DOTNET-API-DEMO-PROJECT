using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerService.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetPlayers();
        T GetPlayer(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}
