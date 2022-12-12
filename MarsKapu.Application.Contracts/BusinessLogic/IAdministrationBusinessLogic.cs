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
        public bool AddUser(User user);
        public List<User> GetUsers();
        public bool ChangeUser(User user);
        public List<News> GetUnapprovedNews();
       
    }
}
