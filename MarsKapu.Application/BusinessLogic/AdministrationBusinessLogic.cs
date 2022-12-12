using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Application.Contracts.Repositories;
using MarsKapu.Application.Contracts.Services;
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
        private readonly IAuthService authService;

        public AdministrationBusinessLogic(INewsDataRepository newsRepository, IAuthService authService)
        {
            this.newsRepository = newsRepository;
            this.authService = authService;
        }
        public void AddUser(User user, string password)
        {
            authService.AddUser(user, password);
        }

        public void ApproveNews(News news)
        {
            newsRepository.UpdateNews(news);
        }

        public void ChangeUser(User user, string password)
        {
            authService.ChangeUser(user, password);
        }

        public List<News> GetUnapprovedNews()
        {
            return newsRepository.GetUnapprovedNews();
        }

        public List<User> GetUsers()
        {
            return authService.GetUsers();
        }

    }
}
