using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MongoRepository<T> : IDisposable, IMongoRepository<T> where T : class
    {
        IMongoCollection<T> mongoCollection;
        IMongoDatabase database;
        MongoClient client;
        public MongoRepository()
        {
            GetDatabase();
            GetCollection();
        }

        protected void GetCollection()
        {
            if (database.GetCollection<T>(typeof(T).Name) == null)
                database.CreateCollection(typeof(T).Name);
            mongoCollection = database.GetCollection<T>(typeof(T).Name);
        }
        
        protected void GetDatabase()
        {
            //var uri = Environment.GetEnvironmentVariable("MONGO_URI");

            client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));
            database = client.GetDatabase(Environment.GetEnvironmentVariable("MONGO_NAME"));
        }

        public void Add(T model)
        {
            this.mongoCollection.InsertOne(model);
        }

        public void Delete(Expression<Func<T, bool>> expression, bool forceDelete=false)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(expression);
            this.mongoCollection.DeleteOne(filter);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(expression);
            return mongoCollection.Find(filter).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> queryable = this.mongoCollection.AsQueryable();
            return queryable;
        }

        public void Update(T model)
        {
            this.mongoCollection.ReplaceOne(null,model);
        }
    }
}
