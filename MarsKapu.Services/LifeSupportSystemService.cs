using MarsKapu.Application.Contracts.Services;
using MarsKapu.DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Services
{
    public class LifeSupportSystemService : ILifeSupportSystemService
    {
        public bool OxygenSystemPower { get; set; } = true;
        public SystemStatus OxygenSystemStatus { get; set; }
        public bool SoilSystemPower { get; set; } = true;
        public SystemStatus SoilSystemStatus { get; set; }

        public void ActivateSafeSystem()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, double> GetOxygenComposition()
        {
            var r = new Random();

            Dictionary<string, double> composition = new Dictionary<string, double>();
            if(OxygenSystemPower == false)
            {
                double oxygen = r.Next(146, 178) / 10.0;
                composition.Add("Oxygen", oxygen);
                composition.Add("Carbon Dioxide", 21 - oxygen);
            }
            else
            {
                double oxygen = r.Next(199, 222) / 10.0;
                composition.Add("Oxygen", oxygen);
                composition.Add("Carbon Dioxide", r.Next(15,28) / 10.0);
            }
            composition.Add("Nitrogen", r.Next(752, 799) / 10.0);
            composition.Add("Hydrogen", r.Next(8, 15) / 10.0);
            composition.Add("Neon", r.Next(8, 15) / 10.0);

            return composition;
            
        }

        public Dictionary<string, double> GetSoilComposition()
        {
            var r = new Random();


            Dictionary<string, double> composition = new Dictionary<string, double>();
                composition.Add("Carbon", r.Next(105,230) / 10.0);
                composition.Add("Hydrogen", r.Next(80, 130) / 10.0);
            composition.Add("Nitrogen", r.Next(320, 410) / 10.0);
            composition.Add("Phosphorus", r.Next(60, 105) / 10.0);
            composition.Add("Molybdenum", r.Next(20, 15) / 10.0);

            return composition;
        }

        public void PowerOxigenSystem()
        {
            OxygenSystemPower = !OxygenSystemPower;
        }

        public void PowerSoilSystem()
        {
            SoilSystemPower = !SoilSystemPower;
        }

        public void SwitchBackUpPower()
        {
            OxygenSystemPower = true;
            SoilSystemPower = true;
        }
    }
}
