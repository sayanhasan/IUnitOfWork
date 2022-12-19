using Deneme.DAL.Abstract.Repositories;
using Deneme.DAL.Abstract.UnitOfWork;
using Deneme.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.DAL.Base
{
    public class UnitWorker : IUnitOfWork
    {
        #region Properties

        public DbContext Context { get; set; }
        public ISubscibeRepo Subscribers { get; private set; }
        public IAddressRepo Address { get; private set; }

        #endregion


        public UnitWorker(DbContext context)
        {
            Context = context;

            Subscribers = new SubscribeRepo() { Worker = this };
            Address = new AddressRepo() { Worker = this };
        }


        public DbSet<T> CreateDbSetInstance<T>() where T : class
        {
            return Context.Set<T>();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
