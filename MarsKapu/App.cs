using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Controllers;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
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
        private readonly ApplicationController appController;
        private readonly ResearchController researchController;
        private User currentUser;
        bool running = true;
        public App(ApplicationController appController, ResearchController researchController)
        {
            this.appController = appController;
            this.researchController = researchController;
        }
        public void Run(string[] args)
        {
            
            
            while (running)
            {
                if(currentUser == null)
                {
                    currentUser = appController.Login();
                }
                else
                {
                    ChooseMenu(Authority.COLONY_LEADER);
                }

            }
            
        }

        public void ChooseMenu(Authority auth)
        {
            appController.AppHeader(currentUser.Name);
            Dictionary<string, Action> menuPoints = new Dictionary<string, Action>();
            menuPoints.Add("Research", () => researchController.ShowResearchList(currentUser.Name));
            menuPoints.Add("Logout", () => currentUser = null);
            menuPoints.Add("Exit", () => running = false);

            var menuPoint = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(menuPoints.Keys.ToArray())
                );
            menuPoints[menuPoint].Invoke();
        }
    }
}
