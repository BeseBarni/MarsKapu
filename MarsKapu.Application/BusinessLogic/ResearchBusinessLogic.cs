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
    public class ResearchBusinessLogic : IResearchBusinessLogic
    {
        private readonly IResearchDataRepository reserachRepo;
        public void AddResearch(Research research)
        {
           reserachRepo.AddResearch(research);
        }

        public List<Research> GetCurrentResearchList()
        {
            return reserachRepo.GetCurrentResearchList();
        }
    }
}
