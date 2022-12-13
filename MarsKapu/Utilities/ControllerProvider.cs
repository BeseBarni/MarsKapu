using MarsKapu.Application.Contracts.Controllers;
using MarsKapu.Controllers;
using MarsKapu.DataContracts.Enums;
using MarsKapu.State;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Utilities
{
    public class ControllerProvider
    {

        private readonly IServiceProvider serviceProvider;

        public ControllerProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            SetController(MenuChoice.APPLICATION);
        }

        public BaseController CurrentController { get; private set; }

        public void SetController(MenuChoice menu)
        {
            switch (menu)
            {
                case MenuChoice.APPLICATION:
                    CurrentController = serviceProvider.GetService<ApplicationController>();
                    break;
                case MenuChoice.ADMINISTRATION:
                    CurrentController = serviceProvider.GetService<AdministrationController>();
                    break;
                case MenuChoice.RESEARCH:
                    CurrentController = serviceProvider.GetService<ResearchController>();
                    break;
                case MenuChoice.LIFE_SUPPORT:
                    CurrentController = serviceProvider.GetService<LifeSupportController>();
                    break;
                case MenuChoice.SUPPLY:
                    CurrentController = serviceProvider.GetService<SupplyController>();
                    break;
                default:
                    CurrentController = serviceProvider.GetService<ApplicationController>();
                    break;
            }
        }
    }
}
