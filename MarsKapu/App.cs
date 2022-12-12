using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Controllers;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
using MarsKapu.State;
using MarsKapu.Utilities;
using Microsoft.Extensions.Configuration;
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
        private readonly AppState appState;
        private readonly ControllerProvider controllerProvider;

        public App(AppState appState, ControllerProvider controllerProvider)
        {
            this.appState = appState;
            this.controllerProvider = controllerProvider;
        }
        public void Run(string[] args)
        {
                    
            while (appState.Running)
            {
                controllerProvider.SetController(controllerProvider.CurrentController.ShowMenu());                
            }
            
        }

    }
}
