using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.BusinessLogic
{
    public class LifeSupportSystemBusinessLogic : ILifeSupportSystemBusinessLogic
    {
        private readonly ILifeSupportSystemService lifeSupportService;

        public LifeSupportSystemBusinessLogic(ILifeSupportSystemService lifeSupportService)
        {
            this.lifeSupportService = lifeSupportService;
        }
        public bool ActivateFailSafeSystem()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, double> GetAtmoshpereComposition()
        {
            return lifeSupportService.GetOxygenComposition();
        }

        public bool GetOxygenSystemPower()
        {
            return lifeSupportService.OxygenSystemPower;
        }

        public Dictionary<string, double> GetSoilComposition()
        {
            return lifeSupportService.GetSoilComposition();
        }

        public bool GetSoilSystemPower()
        {
            return lifeSupportService.SoilSystemPower;
        }

        public void PowerOxigenSystem()
        {
            lifeSupportService.PowerOxigenSystem();
        }

        public void PowerSoilSystem()
        {
            lifeSupportService.PowerSoilSystem();
        }

        public bool SwitchBackUpPower()
        {
            throw new NotImplementedException();
        }
    }
}
