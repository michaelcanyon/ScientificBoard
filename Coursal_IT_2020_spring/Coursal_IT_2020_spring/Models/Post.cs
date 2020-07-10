using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Coursal_IT_2020_spring.Models
{
    public class Post : Entity
    {
        public int AuthorId { get; set; }
        public DateTime Publicationtime { get; set; }
        public string Title { get; set; }
        //public object Image { get; set; }
        public string Text { get; set; }
    }
}
