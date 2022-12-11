using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.DataContracts.Models;
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
        public ResearchController(IResearchBusinessLogic researchBl)
        {
            this.researchBl = researchBl;
        }

        public void ShowResearchList(string name = "")
        {
            AppHeader(name);
            var table = new Table();

            // Add some columns
            table.AddColumn("Research Archive").Centered();
            table.Border(TableBorder.Rounded);
            AnsiConsole.Write(table);

            var researches = new List<Research>()
            {
                new Research()
                { Id = 25424,
                  Title = "Like symbol",
                  Text = "This research is conducted on the effectiveness of passive agression induced by the 👍 symbol\n" +
                  "Prime users of the aforementioned symbol are part of the Homo Intelligentus species, known for their remarkable intelligent quotient.\n" +
                  "The primrary test subject,L234-G-H, has been observed to exhibit extreme signs of sarcasm and stubbornness",
                  PublishDate = DateTime.Now,
                },
                new Research()
                {
                    Id = 45543,
                    Title = "Battle of the wits",
                    Text = "I myself conclude that to compose thy this letter, is to require an exquisite level of mind-state, for which I have long saught after, alas, all in vain, thus, thou shalt not receive.",
                    PublishDate= DateTime.Now,
                }
            };
            var columns = new List<Panel>();
            foreach (var research in researches)
            {

                var researchTable = new Panel(research.Title);

                // Add some columns
                researchTable.Header = new PanelHeader(research.Id.ToString());
                researchTable.Border = BoxBorder.Rounded
                ;
                columns.Add(researchTable);
            }
            AnsiConsole.Write(new Columns(columns));

            var researchName = AnsiConsole.Ask<int>("Enter the selected ID");

            if (researchName == 0)
            {
                return;
            }
            
            ShowResearch(researches.Where(p => p.Id == researchName).First(), name);
        }

        public void ShowResearch(Research research, string name = "")
        {
            AppHeader(name);
            var table = new Table();
            table.Title = new TableTitle("Research");
            // Add some columns
            table.AddColumn(research.Title).Centered();
            table.AddRow(research.Text).Centered();
            table.AddRow(research.PublishDate.ToShortDateString()).Centered();
            table.Width(600);
            table.Border(TableBorder.Rounded);
            AnsiConsole.Write(table);
        }

    }
}
