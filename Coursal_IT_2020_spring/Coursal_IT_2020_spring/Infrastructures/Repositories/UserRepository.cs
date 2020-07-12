using System.Collections.Generic;
using System.Linq;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.IRepositories;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Coursal_IT_2020_spring.Infrastructures
{
    /// <summary>
    /// Действия с объектом пользователя
    /// </summary>
    public class UserRepository : IUserRepository
    {
        protected BoardContext Database { get; set; }
        public UserRepository(BoardContext database)
        {
            Database = database;
        }
        public async Task<bool> ifUsernameBusy(string userName)
        {
            SqlParameter Nickname = new SqlParameter("@Nickname", "%" + userName + "%");
            var users = await Database.Users.FromSqlRaw("SELECT * FROM Users WHERE Nickname LIKE @Nickname", Nickname).ToListAsync();
            return users.Count() != 0 ? true : false;
        }
        public async Task<User> GetByNickname(string nickname, string password)
        {
            SqlParameter Nickname = new SqlParameter("@Nickname", "%" + nickname + "%");
            SqlParameter Password = new SqlParameter("@Password", "%" + password + "%");
            var users = await Database.Users.FromSqlRaw("SELECT * FROM Users WHERE Nickname LIKE @Nickname AND Password LIKE @Password", Nickname, Password).ToListAsync();
            foreach (var i in users)
            {
                return i;
            }
            return null;
        }
        public async Task<User> GetByNickname(string nickname)
        {
            SqlParameter Nickname = new SqlParameter("@Nickname", "%" + nickname + "%");
            var users = await Database.Users.FromSqlRaw("SELECT * FROM Users WHERE Nickname LIKE @Nickname", Nickname).ToListAsync();
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
            SqlParameter userId = new SqlParameter("@userId", UserId);
            var users = await Database.Users.FromSqlRaw("SELECT * FROM Users WHERE Id LIKE @userId ", userId).ToListAsync();
            foreach (var i in users)
            {
                return i;
            }
            return null;
        }

        public async Task Update(User user)
        {
            SqlParameter nickname = new SqlParameter("@nickname", user.Nickname);
            SqlParameter blogTitle = new SqlParameter("@blogTitle", user.BlogTitle);
            SqlParameter email = new SqlParameter("@email", user.Email);
            SqlParameter password = new SqlParameter("@password", user.Password);
            SqlParameter id = new SqlParameter("@id", user.Id);
            await Database.Database.ExecuteSqlRawAsync("UPDATE Users SET Nickname=@nickname, BlogTitle=@blogTitle, Email=@email, Password=@password " +
                "WHERE Id LIKE @id "
                , nickname, blogTitle, email, password, id);
        }
    }
}
