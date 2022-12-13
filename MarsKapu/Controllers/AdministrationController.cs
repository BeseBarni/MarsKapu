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
            foreach (var user in users)
            {
                var panel = new Panel(user.Name);
                panel.RoundedBorder();
                panel.Header = new PanelHeader(user.Id.ToString());
                AnsiConsole.Write(new Columns(panel, new Text(user.UserAuth.ToString())));

            }
            Console.ReadLine();
        }

        public void Adduser()
        {
            AppHeader();
            var rule = new Rule("Name");
            AnsiConsole.Write(rule);
            var name = AnsiConsole.Ask<string>("Please enter the [orangered1]Username[/]: ");

            rule = new Rule("Password");
            AnsiConsole.Write(rule);
            string password = AnsiConsole.Prompt(
               new TextPrompt<string>("Enter the [orangered1]password[/]: ")
                   .PromptStyle("red")
                   .Secret()
                   );

            var authority = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(Enum.GetNames(typeof(Authority)))
                );

            User user = new User(0, name, (Authority)Enum.Parse(typeof(Authority), authority));
            if (!AnsiConsole.Confirm("Do you really want to save it?"))
            {
                return;
            }
            try
            {
                adminBl.AddUser(user, password);

            }
            catch (Exception e)
            {
                return;
            }
        }

        public void ApproveNews()
        {
            AppHeader();
            var news = adminBl.GetUnapprovedNews();
            var title = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(news.Select(p => p.Title))
                );
            var selected = news.Where(p => p.Title == title).First();
            var table = new Table();
            table.Title = new TableTitle(selected.PublishDate.ToString("yyyyy.MM.dd"));
            table.RoundedBorder();
            table.AddColumn(selected.Title);
            table.AddRow(selected.Text);
            AnsiConsole.Write(table);
            if (!AnsiConsole.Confirm("Do you want to approve this news?"))
            {
                return;
            }
            selected.Approved = true;
            adminBl.ApproveNews(selected);
        }
        public override MenuChoice ShowMenu()
        {
            AppHeader();
            Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();

            menuPoints.Add("List users", () => { ShowUsers(); return MenuChoice.ADMINISTRATION; });
            menuPoints.Add("Add user", () => { Adduser(); return MenuChoice.ADMINISTRATION; });
            menuPoints.Add("Approve news", () => { ApproveNews(); return MenuChoice.ADMINISTRATION; });
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
