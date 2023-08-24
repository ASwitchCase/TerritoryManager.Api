using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerritoryManager.Api.Models
{
    public class Territory
    {
        public required string _id { get; set; }
        public required string tid { get; set; }
        public required Publisher publisher { get; set; }
        public required string dateAssigned { get; set; }
        public required string driveLink { get; set; }
    }
}