using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL;

namespace Serveice_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProviderController : ControllerBase
{
    private readonly IProviderManger providerManger;
    private readonly IProviderUser providerUser;

    public ProviderController(IProviderManger providerManger, IProviderUser providerUser)
    {
        this.providerManger = providerManger;
        this.providerUser = providerUser;
    }
    [HttpPost]
    public void add(ProviderWriteDTO providerWriteDTO)
    {
        providerManger.Add(providerWriteDTO);
    }
    [HttpGet]
    [Route("ProvidersByService")]
    public ActionResult<List<ProviderUserReadDTO>> ProvidersByService(string Name)
    {
        return providerUser.GetAllProviders(Name);
    }

    [HttpGet]
    [Route("SelectProviderById")]
    public ActionResult<ProviderReadDTO> ProviderProfile(Guid id)
    {
        return providerUser.GetProviderbyid(id);
    }

}
