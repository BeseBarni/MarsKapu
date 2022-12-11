using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.DataContracts.Models;

namespace MarsKapu.Application.Contracts.BusinessLogic
{
    public interface ISupplyBusinessLogic
    {
        public List<Supply> GetSupplyInventory();
        public void AddSupply(Supply supply);
        public void AddSupplyList(List<Supply> supplies);
        public void RequestSupplies(List<Supply> supplies);
        //public ShipmentStatus GetShipmentStatus();  
    }
}
