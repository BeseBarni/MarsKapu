using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.DataContracts.Models
{
    public class Research
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }

        public Research(int id, string title, string text, DateTime publishDate)
        {
            Id = id;
            Title = title;
            Text = text;
            PublishDate = publishDate;
        }

        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3}", Id, Title, Text, PublishDate.ToString("yyyy/MM/dd"));
        }
    }


}
