using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursal_IT_2020_spring.IRepositories
{
   public interface ITagRepository: IBaseRepository<Tag>
    {
        public Task<Tag> GetSingle(string tag);
    }
}
