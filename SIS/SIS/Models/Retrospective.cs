using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Models
{
    public class Retrospective
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Date { get; set; } // making it a string here but in reality would be a datetime
        public List<string> Participants { get; set; }
        public List<FeedbackItem> Feedback { get; set; }
    }
}