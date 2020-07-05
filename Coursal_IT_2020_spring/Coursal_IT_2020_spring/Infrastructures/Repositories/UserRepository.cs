using System.Collections.Generic;
using System.Linq;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Infrastructures.Repositories;

namespace Coursal_IT_2020_spring.Infrastructures
{
    /// <summary>
    /// Действия с объектом пользователя
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDatabase database) : base(database)
        {
            Collection = database.GetCollection<User>("Authors");
        }
        public async Task<bool> ifUsernameBusy(string userName)
        {
            var filter = Builders<User>.Filter.Eq("Nickname", userName);
            var buff = await Collection.Find(filter).ToListAsync();
            return buff.Count != 0 ? true : false;
        }
        public async Task<User> GetByNickname(string nickname, string password)
        {
            var filter = Builders<User>.Filter.Eq("Password", password) & Builders<User>.Filter.Eq("Nickname", nickname);
            var buff = await Collection.Find(filter).ToListAsync();
            foreach (var i in buff)
            {
                return i;
            }
            return null;
        }
        public async Task<User> GetByNickname(string nickname)
        {
            var filter =Builders<User>.Filter.Eq("Nickname", nickname);
            var buff = await Collection.Find(filter).ToListAsync();
            foreach (var i in buff)
            {
                return i;
            }
            return null;
        }

    }
}
