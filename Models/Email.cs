using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.api.Models
{
    public class Email
    {
        public string Recever { get; set; }
        public string Message { get; set; }
        public string Subject {get; set; }
    }
}