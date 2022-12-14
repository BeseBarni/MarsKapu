using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.BusinessLogic
{
    public interface ILifeSupportSystemBusinessLogic
    {
        //public SystemStatus GetOxigenSystemStatus();
        //public SystemStatus GetSoilSystemStatus();
        public void PowerOxigenSystem();      
        public void PowerSoilSystem();

        public Dictionary<string, double> GetAtmoshpereComposition();
        public Dictionary<string, double> GetSoilComposition();
        public bool GetOxygenSystemPower();
        public bool GetSoilSystemPower();
        public bool SwitchBackUpPower();
        public bool ActivateFailSafeSystem(); 
    }
}
