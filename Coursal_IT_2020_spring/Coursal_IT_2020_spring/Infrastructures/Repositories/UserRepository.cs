using System.Collections.Generic;
using System.Linq;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.EF;
using System.Data.Entity;

namespace Coursal_IT_2020_spring.Infrastructures
{
    /// <summary>
    /// Действия с объектом пользователя
    /// </summary>
    public class UserRepository : IBaseRepository<User>, IUserRepository
    {
        protected BoardContext Database { get; set; }
        public UserRepository(BoardContext database)
        {
            Database = database;
        }
        public async Task<bool> ifUsernameBusy(string userName)
        {
            System.Data.SqlClient.SqlParameter Nickname = new System.Data.SqlClient.SqlParameter("@Nickname", "%" + userName + "%");
            var users = await Database.Database.SqlQuery<User>("SELECT * FROM Users WHERE Nickname LIKE @Nickname", Nickname).ToListAsync();
            return users.Count() != 0 ? true : false;
        }
        public async Task<User> GetByNickname(string nickname, string password)
        {
            System.Data.SqlClient.SqlParameter Nickname = new System.Data.SqlClient.SqlParameter("@Nickname", "%" + nickname + "%");
            System.Data.SqlClient.SqlParameter Password = new System.Data.SqlClient.SqlParameter("@Password", "%" + password + "%");
            var users = await Database.Database.SqlQuery<User>("SELECT * FROM Users WHERE Nickname LIKE @Nickname AND Password LIKE @Password", Nickname, Password).ToListAsync();
            foreach (var i in users)
            {
                return i;
            }
            return null;
        }
        public async Task<User> GetByNickname(string nickname)
        {
            System.Data.SqlClient.SqlParameter Nickname = new System.Data.SqlClient.SqlParameter("@Nickname", "%" + nickname + "%");
            var users = await Database.Database.SqlQuery<User>("SELECT * FROM Users WHERE Nickname LIKE @Nickname", Nickname).ToListAsync();
            foreach (var i in users)
            {
                return i;
            }
            return null;
        }

        public async Task Create(User user)
        {
            Database.Users.Add(user);
            await Database.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            Database.Users.Remove(user);
            await Database.SaveChangesAsync();
        }

        public async Task<List<User>> GetList()
        {
            return await Database.Users.ToListAsync();
        }
        public async Task<User> GetSingle(int UserId)
        {
            System.Data.SqlClient.SqlParameter userId = new System.Data.SqlClient.SqlParameter("@userId", UserId);
            var users = await Database.Database.SqlQuery<User>("SELECT * FROM Users WHERE Id LIKE @userId ", userId).ToListAsync();
            foreach (var i in users)
            {
                return i;
            }
            return null;
        }

        public async Task Update(User user)
        {
            System.Data.SqlClient.SqlParameter nickname = new System.Data.SqlClient.SqlParameter("@nickname", user.Nickname);
            System.Data.SqlClient.SqlParameter blogTitle = new System.Data.SqlClient.SqlParameter("@blogTitle", user.BlogTitle);
            System.Data.SqlClient.SqlParameter email = new System.Data.SqlClient.SqlParameter("@email", user.Email);
            System.Data.SqlClient.SqlParameter password = new System.Data.SqlClient.SqlParameter("@password", user.Password);
            System.Data.SqlClient.SqlParameter id = new System.Data.SqlClient.SqlParameter("@id", user.Id);
            await Database.Database.SqlQuery<User>("UPDATE Users SET Nickname=@nickname, blogTitle=@blogTitle, Email=@email, Password=@password " +
                "WHERE Id LIKE @id "
                , nickname, blogTitle, email, password, id).ToListAsync();
        }
    }
}
