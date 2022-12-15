using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DevFreelaApp.Models;

namespace DevFreelaApp.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectController(IOptions<OpeningTimeOption> option, ExampleClassInjection exampleclassinjection)
        {
            exampleclassinjection.Name = "Updated at ProjectController";
            _option = option.Value;

        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        //api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createproject)
        {
            //return BadRequest
            if (createproject.Title.Length <= 50)
            {
                return BadRequest();
            }

            //cadastrar o projeto
            return CreatedAtAction(nameof(GetById),
            new { id = createproject.Id }, createproject);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {

            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //remove
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createcommentmodel)
        {
            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }

    }
}
