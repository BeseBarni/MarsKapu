using MarsKapu.Application.Contracts.Repositories;
using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Repositories
{
    public class NewsDataRepository : INewsDataRepository
    {
        public void AddNews(News news)
        {
            if (GetAllNews().Where(p => p.Title == news.Title).Count() == 1)
            {
                throw new Exception("Already have this one in the database");
            }
            using (StreamWriter w = new StreamWriter("Repositories/DataBase/News.txt", append : true))
            {
                w.WriteLine(news);
            }

        }

        public List<News> GetAllNews()
        {
            List<News> news = new List<News>();
            using (StreamReader r = new StreamReader("Repositories/DataBase/News.txt"))
            {
                while (r.EndOfStream == false)
                {
                    string line = r.ReadLine();
                    var data = line.Split(";");
                    int id = int.Parse(data[0]);  
                    string title = data[1];
                    string content = data[2];
                    bool approved = data[3] == "0" ? true : false;
                    DateTime published = DateTime.Parse(data[4]);

                    news.Add(new News(id, title, content, approved, published));
                }

            }
            return news;
        }

        public List<News> GetCurrentNews()
        {
            return GetAllNews().Where(p => p.Approved == true).ToList();
        }
        
        //Id;Title;Text;Approved;Date
        public string GetMessageOfTheDay()
        {
            Random rnd = new Random();
            int meantToBe = rnd.Next(1, 22);
            List<String> proverbs = new List<string>();
            using (StreamReader r = new StreamReader("Repositories/DataBase/Wisdom.txt"))
            {
                while (!r.EndOfStream)
                {
                    string line = r.ReadLine();
                    proverbs.Add(line);
                }
            }
            return proverbs[meantToBe];
        }

        public List<News> GetUnapprovedNews()
        {
            return GetAllNews().Where(p => p.Approved == false).ToList();
        }

        public void UpdateNews(News news)
        {
            List<News> all = GetAllNews();
            if (GetAllNews().Where(p => p.Title == news.Title).Count() == 0)
            {
                throw new Exception("No such news yet in the database");
            }
            var itemToRemove = all.Where(p => p.Title == news.Title).First();
            all.Remove(itemToRemove);
            all.Add(news);
            using (StreamWriter w = new StreamWriter("Repositories/DataBase/News.txt", append: false))
            {
                foreach (News item in all)
                    w.WriteLine(item);
            }

        }
    }
}
