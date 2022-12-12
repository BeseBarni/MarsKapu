using MarsKapu.DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.DataContracts.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Authority UserAuth{ get; set; }

        public User(int id, string name, Authority auth)
        {
            Id = id;
            Name = name;
            UserAuth = auth;
        }

        public override string ToString()
        {
            return Id + ";" + Name + ";" + (int)UserAuth;
        }
    }
}
