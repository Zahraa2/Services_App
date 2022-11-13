using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL;

namespace Serveice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderManger providerManger;

        public ProviderController(IProviderManger providerManger)
        {
            this.providerManger = providerManger;
        }
        [HttpPost]
        public void add(ProviderWriteDTO providerWriteDTO)
        {
            providerManger.Add(providerWriteDTO);
        }
    }
}
