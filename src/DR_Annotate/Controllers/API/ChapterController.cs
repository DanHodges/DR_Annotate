using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DR_Annotate.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DR_Annotate.Controllers.API
{
    [Route("api/Chapters")]
    public class ChapterController : Controller
    {

        private ILogger<ChapterController> _logger;
        private IDR_AnnotateRepository _repository;

        public ChapterController(IDR_AnnotateRepository repository, ILogger<ChapterController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet("")]
        public JsonResult Get()
        {
            return Json(_repository.GetAllChapters());
        }

        [Route("{chapter}")]
        [HttpGet("{chapter}")]
        public JsonResult Get(string chapter)
        {
            string ChapterTitle = "Alice in Wonderland";
            return Json(_repository.GetChapterByBookTitleAndNumber(int.Parse(chapter), ChapterTitle));
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
