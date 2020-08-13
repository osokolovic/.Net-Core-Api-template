using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Domain.IRepositories;
using Template.Domain.Models;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TemplateController : ControllerBase
    {
        private readonly ILogger<TemplateController> _logger;
        private readonly ITemplateRepository _templateRepository;
        public TemplateController(ILogger<TemplateController> logger, ITemplateRepository templateRepository)
        {
            _logger = logger;
            _templateRepository = templateRepository;
        }
        [HttpGet]
        [SwaggerOperation(Summary ="Get all courses", Description ="Currenty returns hardcoded template model list")]
        [Authorize]
        public ActionResult<IEnumerable<TemplateModel>> GetAllCourses()
        {
            _logger.LogInformation("GetAllCourses method called");
            var list = new List<TemplateModel>();
            list.Add(new TemplateModel { TemplateId = Guid.NewGuid(), TemplateName = "AA" });
            return Ok(list.AsEnumerable());
            //return Ok(_templateRepository.FindAll());
        }
    }
}
