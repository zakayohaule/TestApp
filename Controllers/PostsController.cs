using Microsoft.AspNetCore.Mvc;
using TestApp.Http;
using TestApp.Http.Requests;

namespace TestApp.Controllers
{
    public class PostsController : Controller
    {
        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] UpdatePostRequest updatePostRequest)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(updatePostRequest);
            }

            return Ok(updatePostRequest);
        }
    }
}