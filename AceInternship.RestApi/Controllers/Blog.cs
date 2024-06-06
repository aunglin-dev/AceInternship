using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AceInternship.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Blog : ControllerBase
    {
        [HttpGet]

        public IActionResult GetBlogs()
        {
            return Ok("GetBlogs");
        }

        [HttpPost]

        public IActionResult CreateBlogs()
        {
            return Ok("CreateBlogs");
        }

        [HttpPut]
        public IActionResult UpdateBlogs()
        {
            return Ok("UpdateBlogs");
        }
        [HttpPatch]
        public IActionResult PatchBlogs()
        {
            return Ok("PatchBlogs");
        }

        [HttpDelete]

        public IActionResult DeleteBlogs()
        {
            return Ok("DeleteBlogs");
        }
    }
}
