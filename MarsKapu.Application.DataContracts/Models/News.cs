using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.DataContracts.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public bool Approved { get; set; }
        public DateTime PublishDate { get; set; }

        public News(int id, string title, string text, bool approved, DateTime publishDate)
        {
            Id = id;
            Title = title;
            Text = text;
            Approved = approved;
            PublishDate = publishDate;
        }
    }
}
