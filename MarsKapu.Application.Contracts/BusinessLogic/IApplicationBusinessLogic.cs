using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.Contracts.BusinessLogic
{
    public interface IApplicationBusinessLogic
    {
        public List<News> GetCurrentNews();
    }
}
