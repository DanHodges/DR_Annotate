using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace DR_Annotate.Models
{
    public class DR_AnnotateContextSeedData
    {
        private DR_AnnotateContext _context;

        public DR_AnnotateContextSeedData(DR_AnnotateContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Chapters.Any() || !_context.Annotations.Any())
            {
                Chapter newChapter = new Chapter();
                newChapter.EntireChapterString = System.IO.File.ReadAllText("./../ch08.txt");

                _context.Chapters.Add(newChapter);

                string json = System.IO.File.ReadAllText("./../ch08.txt.json");
                JArray jsonArray = JArray.Parse(json) as JArray;
                dynamic items = jsonArray;
                foreach (dynamic item in items)
                {
                    Annotation annotation = item.ToObject<Annotation>();
                    _context.Annotations.Add(annotation);
                }
                _context.SaveChanges();
            }
        }
    }
}
