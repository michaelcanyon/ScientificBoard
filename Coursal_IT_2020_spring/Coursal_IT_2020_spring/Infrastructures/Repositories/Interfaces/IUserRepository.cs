using Coursal_IT_2020_spring.Models;
using System.Threading.Tasks;
namespace Coursal_IT_2020_spring.IRepositories
{
    /// <summary>
    /// Пользователь
    /// </summary>
   public interface IUserRepository : IBaseRepository<User>
    {
        public Task<bool> ifUsernameBusy(string userName);
        public Task<User> GetByNickname(string nickname, string password);
        public Task<User> GetByNickname(string nickname);
    }
}
