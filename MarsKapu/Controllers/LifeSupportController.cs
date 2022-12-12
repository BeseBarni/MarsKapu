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
    public class LifeSupportController : BaseController
    {
        public LifeSupportController(AppState appState) : base(appState)
        {
        }

        protected override Color Color { get; set; } = new Color(52, 235, 122);
        protected override string Title { get; set; } = "Martian System Control";

        public void ShowAtmosphereStatus()
        {
            AppHeader();
            AnsiConsole.Write(new Rule("Atmosphere Composition"));
            AnsiConsole.Write(new BreakdownChart()
                .Width(60)
                // Add item is in the order of label, value, then color.
                .AddItem("Oxygen", 22.3, Color.Blue)
                .AddItem("Nitrogen", 67.3, Color.BlueViolet)
                .AddItem("Carbon dioxide", 10.3, Color.Green)
                .AddItem("Argon", 3.1, Color.Purple3));

            Console.ReadLine();
        }

        public void ShowSoilStatus()
        {
            AppHeader();
            AnsiConsole.Write(new Rule("Soil Composition"));
            AnsiConsole.Write(new BreakdownChart()
                .Width(60)
                // Add item is in the order of label, value, then color.
                .AddItem("Carbon", 22.3, Color.DarkSlateGray1)
                .AddItem("Hydrogen", 15, Color.Red3)
                .AddItem("Oxygen", 10.4, Color.Blue3_1)
                .AddItem("Nitrogen", 32.4, Color.Green1)
                .AddItem("Phosphorus", 6.7, Color.OrangeRed1)
                .AddItem("Molybdenum", 2.3, Color.Purple_2));

            Console.ReadLine();
        }
        public override MenuChoice ShowMenu()
        {
            AppHeader();
            Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();
            menuPoints.Add("Atmosphere status", () => { ShowAtmosphereStatus(); return MenuChoice.LIFE_SUPPORT; });
            menuPoints.Add("Soil status", () => { ShowSoilStatus(); return MenuChoice.LIFE_SUPPORT; });
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
