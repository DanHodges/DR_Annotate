using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DR_Annotate.Models
{
    public class Annotation
    {
        public int Id { get; set; }
        public string content { get; set; }
        public string category { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int chapterNumber { get; set; } = 8;
        public string bookTitle { get; set; } = "Alice in Wonderland";
    }
}