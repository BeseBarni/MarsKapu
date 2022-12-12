using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Application.Contracts.Repositories;
using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.BusinessLogic
{
    public class ApplicationBusinessLogic : IApplicationBusinessLogic
    {
        private readonly INewsDataRepository newsRepo;

        
        public ApplicationBusinessLogic(INewsDataRepository newsRepo)
        {
            this.newsRepo = newsRepo;
        }

        public bool AddNews(News news)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<News> GetCurrentNews()
        {
            return newsRepo.GetCurrentNews();
        }

        public string GetMessageOfTheDay()
        {
            throw new NotImplementedException();
        }
    }
}
