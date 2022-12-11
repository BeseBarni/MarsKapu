using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.Services
{
    public interface ILifeSupportSystemService
    {
        //public SystemStatus GetOxigenSystemStatus();
        //public SystemStatus GetSoilSystemStatus();
        public void PowerOxigenSystem();
        public void PowerSoilSystem();
        public void ShutdownOxigenSystem();
        public void ShutdownSoilSystem();
        public void SwitchBackUpPower();
        public void ActivateSafeSystem();

    }
}
