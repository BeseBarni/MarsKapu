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
            int authcode = 0;
            switch (UserAuth)
            {
                case Authority.COLONY_LEADER:
                    authcode = 1;
                    break;
                case Authority.TECHNICIAN:
                    authcode = 2;
                    break;
                case Authority.RESEARCHER:
                    authcode = 3;
                    break;
                case Authority.SUPPLYCHAIN_MANAGER:
                    authcode = 4;
                    break;
                case Authority.CITIZEN:
                    authcode = 5;
                    break;
                case Authority.DENIED:
                    authcode = 6;
                    break;
            }
            return Id + ";" + Name + ";" + authcode;
        }
    }
}
