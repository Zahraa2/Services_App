using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Serveice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManger _serviceManger;

        public ServicesController(IServiceManger serviceManger)
        {
            _serviceManger = serviceManger;
        }
        [HttpGet]
        public ActionResult<List<ServiceReadDTO>> GetServices()
        {
            return _serviceManger.GetAll();
        }

        [HttpGet]
        [Route("ByCatigory/{Name}")]
        
        public ActionResult<List<ServiceReadDTO>> GetServicesByCatigory(string Name)
        {
            var service = _serviceManger.GetServicesByCategory(Name);
            if (service == null)
                return NotFound($"No Services in {Name}");
            return service;
        }

        [HttpGet]
        [Route("MostPopular")]
        public ActionResult<List<ServiceReadDTO>> GetMostPopular()
        {
            return _serviceManger.GetMostServices();
        }
        [HttpPost]
        [Route("ADDService")]
        public void addcatigory(ServiceWriteDTO Service)
        {
            _serviceManger.Add(Service);
        }


    }
}
