using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MySqlBase
{
    public class MySqlRepository<T> : IMySqlRepository<T> where T: class
    {
        private readonly DbContext context;
        private readonly DbSet<T> db;
        public MySqlRepository(DbContext _context)
        {
            context = _context;
            db = context.Set<T>();
        }

        public void Add(T model)
        {
            db.Add(model);
        }

        public void Delete(T model)
        {
            context.Entry(model).State=EntityState.Deleted;  
            db.Attach(model);
            db.Remove(model);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            var data=db.Where(expression);
            return data.FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            var data = db;
            return data;
        }

        public void Update(T model)
        {
            db.Attach(model);
            context.Entry(model).State= EntityState.Modified;
        }
    }
}
