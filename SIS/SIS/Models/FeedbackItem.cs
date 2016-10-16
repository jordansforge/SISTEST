using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Models
{
    public class FeedbackItem
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public string Type { get; set; } // I would make this an Enum with the set types
    }
}
