using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DR_Annotate.Models
{
    public interface IDR_AnnotateRepository
    {
        IEnumerable<Annotation> GetAllAnnotations();
        IEnumerable<Chapter> GetAllChapters();
        Chapter GetChapterByTitleAndNumber(string title, int number);
        void AddChapter(Chapter chapter);
        void AddAnnotation(Annotation annotation);
        void RemoveAnnotation(int id);
        bool SaveAll();
    }
}
