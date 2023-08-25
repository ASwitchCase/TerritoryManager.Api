using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace TerritoryManager.Api.Models
{
    public class User
    {
        public required string username { get; set; }
        public required string password { get; set; }
        public required ObjectId _id { get; set; }
    }
}