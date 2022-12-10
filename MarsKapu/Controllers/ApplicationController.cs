using MarsKapu.Application.Contracts.BusinessLogic;
using Spectre.Console;
using Spectre.Console.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Controllers
{
    public class ApplicationController
    {
        private readonly IApplicationBusinessLogic appBL;

        public ApplicationController(IApplicationBusinessLogic appBL)
        {
            this.appBL = appBL;
        }

        public bool Login()
        {


            var name = AnsiConsole.Ask<string>("Enter your [green]name[/]?");

            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]password[/]?")
                    .PromptStyle("red")
                    .Secret()
                    );

            if (!AnsiConsole.Confirm("Confirm login?"))
            {
                return false;
            }
            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    // Define tasks
                    var task1 = ctx.AddTask("[green]Loggin in[/]");
                    

                    while (!ctx.IsFinished)
                    {
                        Thread.Sleep(50);
                        task1.Increment(1.5);

                    }
                });

            return true;
        }
    }
}
