using MarsKapu.Application.Contracts.Repositories;
using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Repositories
{
    public class ResearchDataRepository : IResearchDataRepository
    {
        public void AddResearch(Research research)
        {
            if (GetCurrentResearchList().Where(p => p.Title == research.Title).Count() == 1)
            {
                throw new Exception("Already have this one in the database");
            }
            using (StreamWriter w = new StreamWriter("Repositories/DataBase/Research.txt", append: true))
            {
                w.WriteLine(research);
            }
        }

        public List<Research> GetCurrentResearchList()
        {
            List<Research> researches = new List<Research>();
            using (StreamReader r = new StreamReader("Repositories/DataBase/Research.txt"))
            {
                while (r.EndOfStream == false)
                {
                    string line = r.ReadLine();
                    var data = line.Split(";");
                    int id = int.Parse(data[0]);
                    string title = data[1];
                    string text= data[2];
                    DateTime published = DateTime.Parse(data[3]);

                    researches.Add(new Research(id, title, text, published));
                }

            }
            return researches;
        }
    }
}
