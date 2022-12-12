using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.DataContracts.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime BestByDate { get; set; }
        public DateTime ShippingDate { get; set; }

        public Supply(int id, string name, int quantity, DateTime bestbydate, DateTime shippingdate)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            BestByDate = bestbydate;
            ShippingDate = shippingdate;
        }

        public override string ToString()
        {
            return Id+";"+Name+";"+Quantity+";"+BestByDate.ToString()+";"+ShippingDate.ToString();
        }
    }
}
