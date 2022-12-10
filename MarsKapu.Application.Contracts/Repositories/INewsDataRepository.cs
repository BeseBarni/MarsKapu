using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.Contracts.Repositories
{
    public interface INewsDataRepository
    {
        public List<News> GetCurrentNews();
    }
}
