using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Controllers;
using MarsKapu.DataContracts.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu
{
    public class App
    {
        private readonly ApplicationController appController;

        public App(ApplicationController appController)
        {
            this.appController = appController;
        }
        public void Run(string[] args)
        {
            appController.Login();
        }
    }
}
