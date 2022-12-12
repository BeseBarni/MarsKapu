using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.BusinessLogic
{
    public interface IAdministrationBusinessLogic
    {   
        public void ApproveNews(News news);
        public void AddUser(User user, string password);
        public List<User> GetUsers();
        public void ChangeUser(User user, string password);
        public List<News> GetUnapprovedNews();
       
    }
}
