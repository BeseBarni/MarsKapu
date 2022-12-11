using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.Contracts.Repositories
{
    public interface INewsDataRepository
    {
        public List<News> GetCurrentNews();
        public List<News> GetUnapprovedNews();
        public void AddNews(News news);
        public void UpdateNews(News news);
        public string GetMessageOfTheDay();
    }
}
