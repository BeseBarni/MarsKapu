using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
using MarsKapu.State;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsKapu.Services;
using MarsKapu.Application.Contracts.BusinessLogic;

namespace MarsKapu.Controllers
{
    public class SupplyController : BaseController
    {
        private readonly ISupplyBusinessLogic supplyB1;

        protected override Color Color { get; set; } = new Color(52, 219, 235);
        protected override string Title { get; set; } = "Martian Supply Control";

        public SupplyController(ISupplyBusinessLogic supplyB1, AppState appState) : base(appState)
        {
            this.supplyB1 = supplyB1;
        }

        public void ShowSupplyList()
        {
            AppHeader();
            List<Supply> supplyList =  supplyB1.GetSupplyInventory();
            var content="";
            foreach (Supply supply in supplyList)
            {
                content += supply.Name + " " + supply.Quantity + " " + supply.BestByDate.ToShortDateString() + "\n";
            }            
            var panel = new Panel(content);
            panel.Header = new PanelHeader("Supplies");
            panel.Border = BoxBorder.Rounded;
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);
            Console.ReadLine();
        }

        public void AddSupply()
        {

            AppHeader();
            var rule = new Rule("item's name:");
            AnsiConsole.Write(rule);
            var name = AnsiConsole.Ask<string>("Please enter the item: ");

            rule = new Rule("Quantity:");
            AnsiConsole.Write(rule);
            var quantity = AnsiConsole.Ask<int>("Quantity: ");

            rule = new Rule("Best by date:");
            AnsiConsole.Write(rule);
            var bestbydate = DateTime.Parse(AnsiConsole.Ask<string>("Best by date: "));

            rule = new Rule("Best by date:");
            AnsiConsole.Write(rule);
            var shippingdate = DateTime.Parse(AnsiConsole.Ask<string>("Shipping by date: "));

            Supply supply = new Supply(0, name, quantity, bestbydate, shippingdate);
            if (!AnsiConsole.Confirm("Do you really want to save it?"))
            {
                return;
            }
            try
            {
                supplyB1.AddSupply(supply);

            }
            catch (Exception e)
            {
                return;
            }
            //MessageBox((IntPtr)0, "News successfully saved", "Success", 0);

        }

        public override MenuChoice ShowMenu()
        {
            AppHeader();
            Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();
            menuPoints.Add("Back to main app", () => MenuChoice.APPLICATION);
            menuPoints.Add("Show Supplies", () => { ShowSupplyList(); return MenuChoice.SUPPLY; });
            menuPoints.Add("Add Supply", () => { AddSupply(); return MenuChoice.SUPPLY;});

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
