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
        private readonly IPostManager _postManger;
        private readonly IProviderManger _providerManger;
        private readonly IMediaManger mediaManger;

        public PostsController(IPostManager postManger, IProviderManger providerManger ,IMediaManger mediaManger)
        {
            _postManger = postManger;
            _providerManger = providerManger;
            this.mediaManger = mediaManger;
        }

        [HttpGet]
        [Route("PostsOfProvider/{ProviderId:Guid}")]
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

        [HttpDelete]
        [Route("DeletePost/{Id:Guid}")]
        public ActionResult DeletePost(Guid Id)
        {
            _postManger.Delete(Id);
            return Ok();
        }

    }
}
