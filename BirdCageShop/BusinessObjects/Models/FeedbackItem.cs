using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class FeedbackItem
    {
        public string UserName { get; set; }
        public string FeedbackName { get; set; }
        public string FeedbackContent { get; set; }
        public double rating { get; set; }
        public string UserIMG { get; set; }
        
    }
}
