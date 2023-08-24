using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerritoryManager.Api.Models
{
    public class Publisher
    {
        public required string name { get; set; }
        public required string email { get; set; }
        public required string phone { get; set; }
    }
}