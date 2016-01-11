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
        IEnumerable<Chapter> GetChapterByBookTitleAndNumber(int number, string title);
        void AddChapter(Chapter chapter);
        void AddAnnotation(Annotation annotation);
        void RemoveAnnotation(int id);
        bool SaveAll();
    }
}
