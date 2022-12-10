using MarsKapu.Application.Contracts.Repositories;
using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Repositories
{
    public class NewsDataRepository : INewsDataRepository
    {
        public List<News> GetCurrentNews()
        {
            return new List<News> { new News() { Title = "Test", Text = "Test Text"} };
        }
    }
}
