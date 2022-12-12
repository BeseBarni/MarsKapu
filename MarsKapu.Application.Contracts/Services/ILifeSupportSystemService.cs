using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.Services
{
    public interface ILifeSupportSystemService
    {
        //public SystemStatus GetOxigenSystemStatus();
        //public SystemStatus GetSoilSystemStatus();

        public bool OxygenSystemPower { get; set; }
        public SystemStatus OxygenSystemStatus { get; set; }
        public bool SoilSystemPower { get; set; }
        public SystemStatus SoilSystemStatus { get; set; }
        public void PowerOxigenSystem();
        public void PowerSoilSystem();

        public Dictionary<string,double> GetOxygenComposition();
        public Dictionary<string, double> GetSoilComposition();
        public void SwitchBackUpPower();
        public void ActivateSafeSystem();

    }
}
