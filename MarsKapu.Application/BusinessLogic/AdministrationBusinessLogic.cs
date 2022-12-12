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
    public class AdministrationBusinessLogic : IAdministrationBusinessLogic
    {
        private readonly INewsDataRepository newsRepository;

        public AdministrationBusinessLogic(INewsDataRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void ApproveNews(News news)
        {
            newsRepository.UpdateNews(news);
        }

        public bool ChangeUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<News> GetUnapprovedNews()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

    }
}
