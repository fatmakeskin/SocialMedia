using DataAccess.MySqlBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public interface IUnitofWork
    {
        int SaveChanges();
        IMySqlRepository<T> GetMySqlRepository<T>() where T : class;
    }
}
