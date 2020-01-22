using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using TestApp.Domains;
using TestApp.Http;
using TestApp.Http.Requests;
using TestApp.Services.Interfaces;
using TestApp.ViewModels;

namespace TestApp.Controllers
{
//    [Authorize(AuthenticationSchemes = "jwt")]
    public class PostsController : Controller
    {
        private readonly HostingEnvironment _environment;
        private readonly IPostService _postService;

        public PostsController(IPostService postService, HostingEnvironment environment)
        {
            _postService = postService;
            _environment = environment;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        public void GetPostCountInTheBackground()
        {
            Console.WriteLine($"There are {_postService.GetAllAsync().Result.Count} posts");
        }

        [HttpGet(ApiRoutes.Posts.GetOne)]
        public async Task<IActionResult> GetOne(int postId)
        {
            var post = await _postService.FindByIdAsync(postId);

            if (post == null) return NotFound();

            return Ok(post);
        }

        [HttpPatch(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] int postId, [FromBody] UpdatePostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var updatedPost = new Post
            {
                Id = postId,
                Name = request.Name
            };

            var updated = await _postService.UpdateAsync(updatedPost);

            if (updated)
                return Ok(updatedPost);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int postId)
        {
            var deletedPost = await _postService.DeleteAsync(postId);

            if (deletedPost)
                return NoContent();
            return NotFound();
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] UpdatePostRequest updatePostRequest)
        {
            var validator = new UpdatePostRequestValidator();
            var result = validator.Validate(updatePostRequest);
            result.AddToModelState(ModelState, null);
            return UnprocessableEntity(ModelState);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(updatePostRequest);
            }
            return Ok(updatePostRequest);
//            if (!ModelState.IsValid)
//            {
//                return UnprocessableEntity(ModelState);
//            }

//            var newPost = new Post
//            {
//                Name = request.
//            };

//            return Ok(newPost);
//            var addedPost = await _postService.CreateAsync(newPost);
//            return Ok(addedPost);
        }
    }
}