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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<News> GetUnapprovedNews()
        {
            throw new NotImplementedException();
        }

        public void UpdateNews(News news)
        {
            throw new NotImplementedException();
        }
    }
}
