using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DR_Annotate.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string title { get; set; } = "Queen's Croquet-Ground";
        public string EntireChapterString { get; set; }
        //public string[] Paragraphs { get; set; }
        public int ChapterNumber { get; set; } = 8;
        public string BookTitle { get; set; } = "Alice in Wonderland";
    }
}
