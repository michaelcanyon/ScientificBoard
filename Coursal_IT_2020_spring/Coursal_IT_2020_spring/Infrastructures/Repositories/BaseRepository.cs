using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.Models;
using Microsoft.Extensions.Configuration;
using Coursal_IT_2020_spring.EF;

namespace Coursal_IT_2020_spring.Infrastructures.Repositories
{
    public abstract class BaseRepository<T>
         where T : Entity
    {
    //    protected IBoardContext Database { get; set; }
    //    protected BaseRepository(IBoardContext database)
    //    {
    //        Database = database;
    //    }
    //    public async Task Create(T entity)
    //    {
    //        await Collection.InsertOneAsync(entity);
    //    }
    //    public async Task<List<T>> GetList()
    //    {
    //        // строитель фильтров
    //        var builder = new FilterDefinitionBuilder<T>();
    //        var filter = builder.Empty; // фильтр для выборки всех документов
    //        return await Collection.Find(filter).ToListAsync();
    //    }
    //    public async Task<T> GetSingle(string id)
    //    {
    //        return await Collection.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
    //    }
    //    public async Task Update(T entity)
    //    {
    //        await Collection.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(entity.Id)), entity);
    //    }
    //    public async Task Delete(T entity)
    //    {
    //        await Collection.DeleteOneAsync(new BsonDocument("_id", new ObjectId(entity.Id)));
    //    }
    //    //protected IMongoDatabase db;
    //    //protected IGridFSBucket gridFS;
    //    //protected IConfiguration Configuration { get; }
    //    //protected BaseRepository()
    //    //{
    //    //    //var client = new MongoClient(settings.ConnectionString);
    //    //    //db = client.GetDatabase(settings.DatabaseName);
    //    //    //gridFS = new GridFSBucket(db);

    //    //}
    }
}
