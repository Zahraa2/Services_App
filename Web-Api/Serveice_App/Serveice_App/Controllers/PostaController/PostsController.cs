using BL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Serveice_App.Controllers.PostaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostManger _postManger;
        private readonly IProviderManger _providerManger;

        public PostsController(IPostManger postManger, IProviderManger providerManger)
        {
            _postManger = postManger;
            _providerManger = providerManger;
        }

        [HttpGet]
        [Route("PostsOfProvider")]
        public ActionResult<List<MediasforPost>> PostsOfProvider(Guid ProviderId)
        {
            var posts = _postManger.GetPostsOfProvider(ProviderId);
            return posts;
        }

        [HttpPost]
        [Route("AddPost")]
        public ActionResult AddPost(PostWriteDTO model)
        {
            var provider = _providerManger.GetByID(model.ProviderId);
            if (provider == null)
            {
                return BadRequest("provider not found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _postManger.Add(model);
            return Ok();
        }

        [HttpPost]
        [Route("UpdatePost")]
        public ActionResult UpdatePost(PostWriteDTO model)
        {
            var provider = _providerManger.GetByID(model.ProviderId);
            if (provider == null)
            {
                return BadRequest("provider not found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _postManger.Update(model);
            return Ok();

        }

        [HttpPost]
        [Route("DeletePost")]
        public ActionResult DeletePost(Guid Id)
        {
            _postManger.Delete(Id);
            return Ok();
        }

    }
}
