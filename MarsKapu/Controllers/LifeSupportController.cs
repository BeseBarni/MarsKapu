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
    public class LifeSupportController : BaseController
    {
        private readonly ILifeSupportSystemBusinessLogic supportBl;
        public LifeSupportController(ILifeSupportSystemBusinessLogic supportBl, AppState appState) : base(appState)
        {
            this.supportBl = supportBl;
        }

        

        protected override Color Color { get; set; } = new Color(52, 235, 122);
        protected override string Title { get; set; } = "Martian System Control";

        public void ShowAtmosphereStatus()
        {
            AppHeader();
            AnsiConsole.Write(new Rule("Atmosphere Composition"));
            BreakdownChart chart = new BreakdownChart().Width(60);
            
            var elements = supportBl.GetAtmoshpereComposition();
            List<Color> colors = new List<Color>();
            colors.Add(Color.DeepPink4_1);
            colors.Add(Color.DarkMagenta);
            colors.Add(Color.DarkViolet);
            colors.Add(Color.Purple4_1);
            colors.Add(Color.BlueViolet);
            colors.Add(Color.RoyalBlue1);
            int i = 0;
            foreach (var item in elements)
            {
                chart.AddItem(item.Key, item.Value, colors[i]);
                i++;
            }
            AnsiConsole.Write(chart);
            Console.ReadLine();
        }

        public void ShowSoilStatus()
        {
            AppHeader();
            AnsiConsole.Write(new Rule("Soil Composition"));
            BreakdownChart chart = new BreakdownChart().Width(60);
            
            var elements = supportBl.GetSoilComposition();
            List<Color> colors = new List<Color>();
            colors.Add(Color.DarkGreen);
            colors.Add(Color.DeepSkyBlue4_1);
            colors.Add(Color.Green4);
            colors.Add(Color.Green3);
            colors.Add(Color.DarkCyan);
            colors.Add(Color.LightCoral);
            colors.Add(Color.SpringGreen2);
            colors.Add(Color.Chartreuse4);
            colors.Add(Color.DarkOrange3);
            int i = 0;
            foreach (var item in elements)
            {
                chart.AddItem(item.Key, item.Value, colors[i]);
                i++;
            }
            AnsiConsole.Write(chart);
            Console.ReadLine();
        }
        public override MenuChoice ShowMenu()
        {
            AppHeader();
            Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();
            menuPoints.Add("Atmosphere status", () => { ShowAtmosphereStatus(); return MenuChoice.LIFE_SUPPORT; });
            menuPoints.Add("Soil status", () => { ShowSoilStatus(); return MenuChoice.LIFE_SUPPORT; });
            if (supportBl.GetOxygenSystemPower())
            {
                menuPoints.Add("Oxygen system status: On", () => { supportBl.PowerOxigenSystem(); return MenuChoice.LIFE_SUPPORT; });
            }
            else
            {
                menuPoints.Add("Oxygen system status: Off", () => { supportBl.PowerOxigenSystem(); return MenuChoice.LIFE_SUPPORT; });

            }
            if (supportBl.GetSoilSystemPower())
            {
                menuPoints.Add("Soil system status: On", () => { supportBl.PowerSoilSystem(); return MenuChoice.LIFE_SUPPORT; });
            }
            else
            {
                menuPoints.Add("Soil system status: Off", () => { supportBl.PowerSoilSystem(); return MenuChoice.LIFE_SUPPORT; });

            }
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
