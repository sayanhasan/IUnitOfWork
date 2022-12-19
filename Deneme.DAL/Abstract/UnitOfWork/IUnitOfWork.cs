using Deneme.DAL.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.DAL.Abstract.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ISubscibeRepo Subscribers { get; }
        IAddressRepo Address { get; }
        int SaveChanges();
    }
}
