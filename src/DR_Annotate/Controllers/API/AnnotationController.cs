using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR_Annotate.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DR_Annotate.Controllers.API
{
    [Route("api/Annotations")]
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
            return Json(new { results = annotations });
        }

        [HttpPost("")]
        public JsonResult Post([FromBody] string annotationInput)
        {

            JObject jsonObject = JObject.Parse(annotationInput);
            dynamic item = jsonObject;
            Annotation annotation = item.ToObject<Annotation>();
            try
            {
                _repository.AddAnnotation(annotation);

                _logger.LogInformation("Attempting to save a new Annotation");

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
    }
}
