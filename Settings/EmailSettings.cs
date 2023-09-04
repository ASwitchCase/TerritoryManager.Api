using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailSender.api.Models;

namespace TerritoryManager.Api.Settings
{
    public class EmailSettings
    {
        private IConfiguration configuration;
        private readonly string ? User;
        private readonly string? Password;
        public EmailSettings(IConfiguration configuration){
            this.configuration = configuration;
            User = configuration.GetConnectionString("GUSER");
            Password = configuration.GetConnectionString("GPASS");
        }
        public string GetUserEmail(){
            return User;
        }
        public string GetEmailPassword(){
            return Password;
        }
    }
}