using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.Contracts.BusinessLogic
{
    public interface IApplicationBusinessLogic
    {
        public List<News> GetCurrentNews();
        public bool AddNews(News news);
        public string GetMessageOfTheDay();
        public bool AuthenticateUser(User user);
        //public Authority AuthorizeUser(User user);
    }
}
