using Data.Context;
using DataAccess.MySqlBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private DbContext context;
        public DbContext dbContext
        {
            get
            {
                if(context==null)
                    context = new MasterContext();
                return context;
            }
            set 
            {  
                context = value;                 
            }
        }
        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IMySqlRepository<T> GetMySqlRepository<T>() where T : class
        {
            return new MySqlRepository<T>(dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                int result = dbContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
