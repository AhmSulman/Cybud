using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Cybud_WPF_0._1.Models
{
    public class JournalEntry
    {
        public DateTime Date { get; set; }
        
        public string Title { get; set; }
        public string Note { get; set; }
        public string name { get; set; }
        public string Content { get; set; }
        public string description { get; set; }

        public JournalEntry()
        {
            Date = DateTime.Now;
        }
    }
}
