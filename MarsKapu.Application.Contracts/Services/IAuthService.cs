using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.Services
{
    public interface IAuthService
    {
        public void AddUser(User user, string password);
        public List<User> GetUsers();
        public void ChangeUser(User user, string password);
        public bool AuthenticateUser(User user);
        public User? AuthorizeUser(User user, string password);
    }
}
