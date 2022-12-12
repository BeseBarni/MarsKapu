using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.DataContracts.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Approved { get; set; }
    }
}
