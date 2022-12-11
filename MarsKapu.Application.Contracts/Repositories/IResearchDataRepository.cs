using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.Repositories
{
    public interface IResearchDataRepository
    {
        public List<Research> GetCurrentResearchList();
        public void AddResearch(Research research);
    }
}
