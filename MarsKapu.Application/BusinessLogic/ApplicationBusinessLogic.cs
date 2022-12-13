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
    public class ApplicationBusinessLogic : IApplicationBusinessLogic
    {
        private readonly INewsDataRepository newsRepo;
        private readonly IAuthService authService;

        public ApplicationBusinessLogic(INewsDataRepository newsRepo, IAuthService authService)
        {
            this.newsRepo = newsRepo;
            this.authService = authService;
        }

        public void AddNews(News news)
        {
            newsRepo.AddNews(news);
        }

        public bool AuthenticateUser(User user)
        {
            return authService.AuthenticateUser(user);
        }

        public User? AuthorizeUser(User user, string password)
        {
            return authService.AuthorizeUser(user, password);
        }

        public List<News> GetCurrentNews()
        {
            return newsRepo.GetCurrentNews();
        }

        public string GetMessageOfTheDay()
        {
            return newsRepo.GetMessageOfTheDay();
        }
    }
}
