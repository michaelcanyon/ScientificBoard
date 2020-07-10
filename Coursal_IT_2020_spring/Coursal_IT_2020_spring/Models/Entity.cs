using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Coursal_IT_2020_spring.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
