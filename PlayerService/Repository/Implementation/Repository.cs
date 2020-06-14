using PlayerService.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerService.Repository
{
    class Repository<T> : IRepository<T>, IDisposable where T : class
    {

        private IDbSet<T> table = null;
        private string errorMessage = string.Empty;
        private bool isDisposed;

        public SampleDBEntities Context { get; set; }

        public Repository(IUnitOfWork<SampleDBEntities> unitOfWork) : this(unitOfWork.Context)
        {
            
        }

        public Repository(SampleDBEntities context)
        {
            isDisposed = false;
            Context = context;
            table = context.Set<T>();
        }

        public void Delete(object id)
        {
            table.Remove(table.Find(id));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    Dispose();
                }
                isDisposed = true;
            }
        }

        public T GetPlayer(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetPlayers()
        {
            return table.ToList();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }
    }
}
