using Coursal_IT_2020_spring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursal_IT_2020_spring.EF
{
    /// <summary>
    /// Здесь пока все не очень хорошо. Игнорируй этот файл
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public interface IBoardContext<T> where T: Entity
    {
        //public DbSet<T> ObjSet { get; set; }
    }
}
