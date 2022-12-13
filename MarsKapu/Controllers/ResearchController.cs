using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
using MarsKapu.State;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Controllers
{
    public class ResearchController : BaseController
    {
        private readonly IResearchBusinessLogic researchBl;
        protected override Color Color { get; set; } = new Color(111, 22, 219);
        protected override string Title { get; set; } = "Martian Research";
        public ResearchController(IResearchBusinessLogic researchBl, AppState appState) : base(appState)
        {
            this.researchBl = researchBl;
        }
        public void ShowResearchList()
        {
            AppHeader();
            var researchList = researchBl.GetCurrentResearchList();

            foreach (var research in researchList)
            {
                var table = new Table();
                // Add some columns
                table.Title(research.PublishDate.ToString("yyyy.MM.dd"));
                table.AddColumn(research.Title);
                table.AddRow(research.Text);

                table.Border(TableBorder.Rounded);
                table.Centered();
                AnsiConsole.Write(table);
            }
            Console.ReadLine(); 
        }

        public void AddResearch()
        {

            AppHeader();
            var rule = new Rule("Title");
            AnsiConsole.Write(rule);
            var title = AnsiConsole.Ask<string>("Please enter the title: ");

            rule = new Rule("Text");
            AnsiConsole.Write(rule);
            var text = AnsiConsole.Ask<string>("");

            Research research = new Research(0, title, text, DateTime.Now);
            if (!AnsiConsole.Confirm("Do you really want to save it?"))
            {
                return;
            }
            try
            {
                researchBl.AddResearch(research);

            }
            catch (Exception e)
            {
                return;
            }
            //MessageBox((IntPtr)0, "News successfully saved", "Success", 0);

        }

        public void ShowResearch(Research research)
        {
            AppHeader();
            var table = new Table();
            table.Title = new TableTitle("Research");
            // Add some columns
            table.AddColumn(research.Title).Centered();
            table.AddRow(research.Text).Centered();
            table.AddRow(research.PublishDate.ToShortDateString()).Centered();
            table.Width(600);
            table.Border(TableBorder.Rounded);
            AnsiConsole.Write(table);
            Console.ReadLine();
        }

        public override MenuChoice ShowMenu()
        {
            AppHeader();
            Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();
            menuPoints.Add("Show Researches", () => { ShowResearchList(); return MenuChoice.RESEARCH; });
            menuPoints.Add("Add Research", () => { AddResearch(); return MenuChoice.RESEARCH; });
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
