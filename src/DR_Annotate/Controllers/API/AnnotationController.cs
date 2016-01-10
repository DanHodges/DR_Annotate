using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR_Annotate.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json;

namespace DR_Annotate.Controllers.API
{
    [Route("api/Annotation")]
    public class AnnotationController : Controller
    {
        private ILogger<AnnotationController> _logger;
        private IDR_AnnotateRepository _repository;

        public AnnotationController(IDR_AnnotateRepository repository, ILogger<AnnotationController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var annotations = _repository.GetAllAnnotations();
            //var results = Mapper.Map<IEnumerable<InstrumentViewModel>>(Instruments);
            return Json(new { results = annotations });
        }
        [HttpPost("")]
        public JsonResult Post([FromBody] object annotation)
        {

            Annotation Annotation = new Annotation();
            
            try
            {

               // _repository.AddAnnotation(annotation);

                //NewInstrument.UserName = User.Identity.Name;

                //Save to Database
                _logger.LogInformation("Attempting to save a new Annotation");
                //_repository.AddInstrument(NewInstrument);

                if (_repository.SaveAll())
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Annotation", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed");
        }
        //[HttpPost("")]
        //public JsonResult Post([FromBody] IEnumerable<Annotation> annotations)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            foreach (Annotation annotation in annotations)
        //            {
        //                _repository.AddAnnotation(annotation);
        //            }

        //            //NewInstrument.UserName = User.Identity.Name;

        //            //Save to Database
        //            _logger.LogInformation("Attempting to save a new Instrument");
        //            //_repository.AddInstrument(NewInstrument);

        //            if (_repository.SaveAll())
        //            {
        //                Response.StatusCode = (int)HttpStatusCode.Created;
        //                return Json(Response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Failed to save new Instrument", ex);
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json(new { Message = ex.Message });
        //    }
        //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //    return Json("Failed");
        //}
    }
}
