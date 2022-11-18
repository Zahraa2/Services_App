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
    [Route("ProvidersByService/{Name}")]
    public ActionResult<List<ProviderUserReadDTO>> ProvidersByService(string Name)
    {
        var providerlist= providerUser.GetAllProviders(Name);
        if(providerlist==null)
        {
            return NotFound($"NO Providers in {Name}");
        }
        return providerlist;
    }

    [HttpGet]
    [Route("SelectProviderById/{id}")]
    public ActionResult<ProviderReadDTO> ProviderProfile(Guid id)
    {
        var provider = providerUser.GetProviderbyid(id);
        if (provider == null)
            return NotFound("This Provider Not Found");
        return provider;
    }

    [HttpPost]
    [Route("EditProviderProfile")]
    public ActionResult EditProviderProfile(ProviderUserWriteDTO providerUserWriteDTO)
    {
        var flag = providerUser.EditProvider(providerUserWriteDTO);
        if (flag)
            return Ok("Edit Done");
        return BadRequest("This Provider Not Found");

    }

}
