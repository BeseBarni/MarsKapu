using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Enums;
using MarsKapu.State;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Controllers
{
    public class AdministrationController : BaseController
    {
        private readonly IAdministrationBusinessLogic adminBl;

        public AdministrationController(AppState appState, IAdministrationBusinessLogic adminBl) : base(appState)
        {
            this.adminBl = adminBl;
        }

        protected override Color Color { get; set; } = new Color(214, 13, 13);
        protected override string Title { get; set; } = "Martian Administration";

        public void ShowUsers()
        {
            AppHeader();

            var users = adminBl.GetUsers();
        }
        public override MenuChoice ShowMenu()
        {
            AppHeader();
            Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();

            menuPoints.Add("List Users", () => { ShowUsers(); return MenuChoice.ADMINISTRATION; });
            menuPoints.Add("Back to main app", () => MenuChoice.APPLICATION);
            menuPoints.Add("Logout", () => LogOut());
            menuPoints.Add("Exit", () => { appState.Running = false; return MenuChoice.EXIT; });

            var menuPoint = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(menuPoints.Keys.ToArray())
                );
            return menuPoints[menuPoint].Invoke();
        }
    }
}
