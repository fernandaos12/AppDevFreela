using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.InputModels;

namespace DevFreelaApp.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {        
        private readonly IProjectService _projectservice;
        public ProjectController(IProjectService projectService)
        {
            projectService = _projectservice;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var project = _projectservice.GetAll(query);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        //api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectservice.GetById(id);  
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputmodel)
        {
            //return BadRequest
            if (inputmodel.Title.Length <= 50)
            {
                return BadRequest();
            }

            var id = _projectservice.Create(inputmodel);

            //cadastrar o projeto
            return CreatedAtAction(nameof(GetById),new { id = id }, inputmodel);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputmodel)
        {

            if (inputmodel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectservice.Update(inputmodel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectservice.Delete(id);
            //remove
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputmodel)
        {
            _projectservice.CreateComment(inputmodel);
            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectservice.Start(id);
            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectservice.Finish(id);
            return NoContent();
        }

    }
}
