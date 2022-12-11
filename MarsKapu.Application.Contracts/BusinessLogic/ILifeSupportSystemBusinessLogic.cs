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
        public bool PowerOxigenSystem();      
        public bool PowerSoilSystem();
        public bool ShutdownOxigenSystem();
        public bool ShutdownSoilSystem();
        public bool SwitchBackUpPower();
        public bool ActivateFailSafeSystem(); 
    }
}
