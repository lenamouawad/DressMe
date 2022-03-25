using DressMe.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DressMe.DTO
{
    public class Article
    {
        public string IdInCategory { get; set; }
        public int Category { get; set; }
        public string ImgUrl { get; set; }

        public Article()
        {
        }

        public Article(string idInCategory, int category, string imgUrl)
        {
            this.IdInCategory = idInCategory;
            this.Category = category;
            this.ImgUrl = imgUrl;
        }
    }
}
