using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
using MarsKapu.State;
using Spectre.Console;
using Spectre.Console.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Controllers
{
    public class ApplicationController : BaseController
    {
        private readonly IApplicationBusinessLogic appBL;
        protected override Color Color { get; set; } = new Color(255, 77, 0);
        protected override string Title { get; set; } = "Martian Gate";

        public ApplicationController(IApplicationBusinessLogic appBL, AppState appState) : base(appState)
        {
            this.appBL = appBL;
        }

        public void Login()
        {

            var name = AnsiConsole.Ask<string>("Enter your [orangered1]name[/]: ");

            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [orangered1]password[/]: ")
                    .PromptStyle("red")
                    .Secret()
                    );
            AnsiConsole.WriteLine();
            User? currentUser = null;
            AnsiConsole.Status()
                .Start("[orangered1]Running ID check[/]", ctx =>
                {
                // Simulate some work
                ctx.Spinner(Spinner.Known.BouncingBar);
                AnsiConsole.MarkupLine("[gray]LOG: [/] Searching in Martian database");
                Thread.Sleep(900);
                if (appBL.AuthenticateUser(new User(0, name, 0)))
                    AnsiConsole.MarkupLine(String.Format("[gray]LOG: [/] {0} [green]online[/]", name));
                else
                {
                    AnsiConsole.MarkupLine(String.Format("[gray]LOG: [/] {0} [red]offline[/]", name));
                    Thread.Sleep(900);
                    return;
                }
                ctx.Status("Checking priviliges");
                Thread.Sleep(900);
                ctx.Spinner(Spinner.Known.SimpleDots);
                currentUser = appBL.AuthorizeUser(new User(0, name, 0), password);
                if(currentUser != null)
                    AnsiConsole.MarkupLine("[gray]LOG: [/] Privilige found: [orangered1]" + currentUser.UserAuth + "[/]");
                else
                {
                    AnsiConsole.MarkupLine("[gray]LOG: [/]Password is incorrect");
                }
                    ctx.Status("Finalizing");
                    Thread.Sleep(1300);                   
                });            
            
            
            appState.MessageOfTheDay = appBL.GetMessageOfTheDay();
            appState.CurrentUser = currentUser;

        }

        public void ShowNews()
        {
            AppHeader();

            var newsList = appBL.GetCurrentNews();

            foreach (var news in newsList)
            {
                var table = new Table();
                // Add some columns
                table.Title(news.PublishDate.ToString("yyyy.MM.dd"));
                table.AddColumn(news.Title);
                table.AddRow(news.Text);
                
                table.Border(TableBorder.Rounded);
                table.Centered();
                AnsiConsole.Write(table);

            }
            Console.ReadLine();
        }

        public void AddNews(bool isTechnician = false)
        {

            AppHeader();
            var rule = new Rule("Title");
            AnsiConsole.Write(rule);
            var title = AnsiConsole.Ask<string>("Please enter the title: ");

            rule = new Rule("Text");
            AnsiConsole.Write(rule);
            var text = AnsiConsole.Ask<string>("");

            News news = new News(0, title, text, isTechnician, DateTime.Now);
            if (!AnsiConsole.Confirm("Do you really want to save it?"))
            {
                return;
            }
            try
            {
                Console.WriteLine();
                AnsiConsole.Status()
               .Start("[orangered1]Connecting to Database[/]", ctx =>
               {
                   // Simulate some work
                   ctx.Spinner(Spinner.Known.BouncingBar);
                   AnsiConsole.MarkupLine("[gray]LOG: [/] Establishin connection with Database");
                   Thread.Sleep(900);
                   AnsiConsole.MarkupLine("[gray]LOG: [/] Communication [green]ONLINE[/]");
                   Thread.Sleep(900);
                   ctx.Status("Saving News");
                   Thread.Sleep(900);
                   ctx.Spinner(Spinner.Known.SimpleDots);

                   ctx.Status("Finalizing");
                   Thread.Sleep(1300);
               });
                appBL.AddNews(news);
            }
            catch (Exception e)
            {

                Console.WriteLine();
                AnsiConsole.Write(new Markup("[gray]LOG: [/][red]" + e.Message + "[/]"));
                Console.ReadLine();
                return;
            }
            Console.WriteLine();
            AnsiConsole.Write(new Markup("[gray]LOG: [/][green]News successfuly saved[/]"));
            Console.ReadLine();

        }


        public void ShowMusk() {
            AnsiConsole.Clear();
            var image = new CanvasImage("Resources/ElonMusk.jpg");

            // Set the max width of the image.
            // If no max width is set, the image will take
            // up as much space as there is available.
            image.MaxWidth(20);
            AnsiConsole.Write(image);
            Console.ReadLine();
        }

        public override MenuChoice ShowMenu()
        {
            AppHeader();
            if (appState.CurrentUser == null)
            {
                Login();
                return MenuChoice.APPLICATION;
            }
            else
            {
                var image = new CanvasImage("Resources/CharLogo.png");
                
                // Set the max width of the image.
                // If no max width is set, the image will take
                // up as much space as there is available.
                image.MaxWidth(16);

                var table = new Table();
                table.AddColumn("User: " + appState.CurrentUser.Name);
                table.AddRow("Authority: " + appState.CurrentUser.UserAuth);
                table.RoundedBorder();
                

                var calendar = new Calendar(DateTime.Now.Year, DateTime.Now.Month);
                calendar.AddCalendarEvent(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                calendar.HighlightStyle(Style.Parse("orangered1 bold"));
                calendar.RightAligned();

                var panel = new Panel(appState.MessageOfTheDay);
                panel.Header = new PanelHeader("Message of the day");
                panel.Border = BoxBorder.Rounded;
                var padder = new Padder(panel.PadBottom(2).PadTop(2));
                AnsiConsole.Write(new Columns(
                     padder,calendar
                    ));


                Dictionary<string, Func<MenuChoice>> menuPoints = new Dictionary<string, Func<MenuChoice>>();

                menuPoints.Add("Current News", () => { ShowNews(); return MenuChoice.APPLICATION; });

                if (appState.CurrentUser.UserAuth == Authority.COLONY_LEADER)
                {
                    menuPoints.Add("Add News", () => { AddNews(true); return MenuChoice.APPLICATION; });
                    menuPoints.Add("Administration", () => MenuChoice.ADMINISTRATION);
                    menuPoints.Add("Supply Management", () => MenuChoice.SUPPLY);
                    menuPoints.Add("Research", () => MenuChoice.RESEARCH);
                    menuPoints.Add("Life Support", () => MenuChoice.LIFE_SUPPORT);
                }

                if (appState.CurrentUser.UserAuth == Authority.SUPPLYCHAIN_MANAGER)
                {
                    menuPoints.Add("Add News", () => { AddNews(); return MenuChoice.APPLICATION; });
                    menuPoints.Add("Supply Management", () => MenuChoice.SUPPLY);
                }

                if (appState.CurrentUser.UserAuth == Authority.RESEARCHER)
                { 
                    menuPoints.Add("Add News", () => { AddNews(); return MenuChoice.APPLICATION; });
                    menuPoints.Add("Research", () => MenuChoice.RESEARCH);
                }

                if (appState.CurrentUser.UserAuth == Authority.TECHNICIAN) {
                    menuPoints.Add("Add News", () => { AddNews(true); return MenuChoice.APPLICATION; });
                    menuPoints.Add("Life Support", () =>MenuChoice.LIFE_SUPPORT);
                }

                menuPoints.Add("Logout", () => LogOut());
                menuPoints.Add("Exit", () => { appState.Running = false; return MenuChoice.EXIT; });

                var menuPoint = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .AddChoices(menuPoints.Keys.ToArray())
                    );
                return menuPoints[menuPoint].Invoke();
            
            }
        }


    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);

}
}
