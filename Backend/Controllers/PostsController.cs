using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _tittlesService;

        public PostsController(IPostsService tittlesService)
        {
            _tittlesService = tittlesService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDTO>> Get() => await _tittlesService.Get();
    }
}
