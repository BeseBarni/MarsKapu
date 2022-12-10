using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Models;
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
        private readonly IApplicationBusinessLogic appBl;

        public App(IApplicationBusinessLogic appBl)
        {
            this.appBl = appBl;
        }
        public void Run(string[] args)
        {
            News news = appBl.GetCurrentNews().First();
            var table = new Table();

            // Add some columns
            table.AddColumn(new TableColumn(news.Title).Centered());

            // Add some rows
            table.AddRow(news.Text);

            // Render the table to the console
            AnsiConsole.Write(table);
        }
    }
}
