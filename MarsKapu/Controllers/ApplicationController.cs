using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Models;
using Spectre.Console;
using Spectre.Console.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Controllers
{
    public class ApplicationController : BaseController
    {
        private readonly IApplicationBusinessLogic appBL;
        protected override Color Color { get; set; } = new Color(255, 77, 0);
        protected override string Title { get; set; } = "Martian Gate";

        public ApplicationController(IApplicationBusinessLogic appBL)
        {
            this.appBL = appBL;
        }


        public User? Login()
        {
            AppHeader();

            var name = AnsiConsole.Ask<string>("Enter your [orangered1]name[/]: ");

            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [orangered1]password[/]: ")
                    .PromptStyle("red")
                    .Secret()
                    );
            AnsiConsole.WriteLine();
            AnsiConsole.Status()
                .Start("[orangered1]Running ID check[/]", ctx =>
                {
                    // Simulate some work
                    ctx.Spinner(Spinner.Known.BouncingBar);
                    AnsiConsole.MarkupLine("[gray]LOG: [/] Searching in Martian database");
                    Thread.Sleep(900);
                    AnsiConsole.MarkupLine(String.Format("[gray]LOG: [/] {0} [green]online[/]",name));
                    Thread.Sleep(900);
                    ctx.Status("Checking priviliges");
                    ctx.Spinner(Spinner.Known.SimpleDots);

                    AnsiConsole.MarkupLine("[gray]LOG: [/] Privilige found");
                    Thread.Sleep(900);                   
                });

            return new User() { Name = name, Id = 21313 };

        }

        
    }
}
