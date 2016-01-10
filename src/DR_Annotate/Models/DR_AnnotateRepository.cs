using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DR_Annotate.Models
{
    public class DR_AnnotateRepository : IDR_AnnotateRepository
    {
        public DR_AnnotateContext _context;
        private ILogger<DR_AnnotateRepository> _logger;
        
        public DR_AnnotateRepository(DR_AnnotateContext context, ILogger<DR_AnnotateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddAnnotation(Annotation newAnnotation)
        {
            _context.Annotations.Add(newAnnotation);
        }

        public void AddChapter(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
        }

        public IEnumerable<Annotation> GetAllAnnotations()
        {
            try
            {
                return _context.Annotations
                    .OrderBy(t => t.bookTitle)
                    .OrderBy(t => t.chapterNumber)
                    .OrderBy(t => t.start);
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Annotations from database", ex);
                return null;
            }
        }

        public IEnumerable<Chapter> GetAllChapters()
        {
            return _context.Chapters
                .OrderBy(t => t.BookTitle)
                .OrderBy(t => t.ChapterNumber);
        }

        public Chapter GetChapterByTitleAndNumber(string title, int number)
        {
            var chapter = _context.Chapters
                .Where(t => t.BookTitle == title && t.ChapterNumber == number);
            return chapter as Chapter;
        }

        public void RemoveAnnotation(int id)
        {
            var toBeRemoved = _context.Annotations;
                //.Where(t => t.Id == id);
            _context.Remove(toBeRemoved);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
