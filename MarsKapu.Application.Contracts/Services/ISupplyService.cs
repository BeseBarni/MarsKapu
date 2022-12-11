using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.Contracts.Services
{
    public interface ISupplyService
    {
        public void RequestSupplies(List<Supply> supplies);
        //public ShipmentStatus GetShipmentStatus();
        public List<Supply> GetSupplyInventory ();
        public void AddSupply(Supply supply);
        public void AddSupplyList(List<Supply> supplies);
    }
}
