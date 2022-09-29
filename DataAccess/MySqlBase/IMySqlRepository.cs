using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MySqlBase
{
    public interface IMySqlRepository<T> where T : class 
    {
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void Delete(T model);
        void Add(T model);
        void Update(T model);

    }
}
