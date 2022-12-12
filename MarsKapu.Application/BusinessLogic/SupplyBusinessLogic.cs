using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Application.BusinessLogic
{
    public class SupplyBusinessLogic : ISupplyBusinessLogic
    {
        public void AddSupply(Supply supply)
        {
            List<Supply> supplies = GetSupplyInventory();
            int index = 0;
            while (index < supplies.Count && supplies[index].Id != supply.Id)
            {
                index++;
            }
            if (index == supplies.Count)
            {
                supplies.Add(supply);
            }
            else
            {
                supplies[index].Quantity += supply.Quantity;
                supplies[index].BestByDate = supply.BestByDate;
                supplies[index].ShippingDate = supply.ShippingDate;
            }
            List<string> output = new List<string>();
            foreach (var item in supplies)
            {
                output.Add(item.ToString());
            }
            File.WriteAllLines("Repositories/DataBase/Supplies.txt", output);
        }

        public void AddSupplyList(List<Supply> supplies)
        {
            throw new NotImplementedException();
        }

        public List<Supply> GetSupplyInventory()
        {
            List<Supply> supplies = new List<Supply>();
            using (StreamReader r = new StreamReader("Repositories/DataBase/Supplies.txt"))
            {
                while (r.EndOfStream == false)
                {
                    string line = r.ReadLine();
                    var data = line.Split(";");
                    int id = int.Parse(data[0]);
                    string name = data[1];
                    int quantity = int.Parse(data[2]);
                    DateTime bestbydate = DateTime.Parse(data[3]);
                    DateTime shippingdate = DateTime.Parse(data[4]);
                    supplies.Add(new Supply(id, name, quantity, bestbydate, shippingdate));
                }
            }
            return supplies;
        }

        public void RequestSupplies(List<Supply> supplies)
        {
            throw new NotImplementedException();
        }
    }
}
