using MarsKapu.Application.Contracts.Controllers;
using MarsKapu.Controllers;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
using MarsKapu.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.State
{
    public class AppState
    {
        public bool Running { get; set; }
        public User? CurrentUser { get; set; }

        public AppState()
        {
            Running = true;
        }
    }
}
