using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Serveice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManger _serviceManger;
        private readonly IStringLocalizer<ServicesController> _localizer;

        public ServicesController(IServiceManger serviceManger, IStringLocalizer<ServicesController> localizer)
        {
            _serviceManger = serviceManger;
            _localizer = localizer;
        }
        [HttpGet]
        public ActionResult<List<ServiceReadDTO>> GetServices()
        {
            var services = _serviceManger.GetAll();
            return LocalizeService(services);
        }

        [HttpGet]
        [Route("ByCatigory/{Name}")]

        public ActionResult<List<ServiceReadDTO>> GetServicesByCatigory(string Name)
        {
            var service = _serviceManger.GetServicesByCategory(Name);

            if (service == null)
                return NotFound($"No Services in {Name}");

            return LocalizeService(service);
        }

        [HttpGet]
        [Route("MostPopular")]
        public ActionResult<List<ServiceReadDTO>> GetMostPopular()
        {
            var services = _serviceManger.GetMostServices();
            return LocalizeService(services);
        }
        [HttpPost]
        [Route("AddService")]
        public void AddService(ServiceWriteDTO Service)
        {
            _serviceManger.Add(Service);
        }
        [HttpGet]
        [Route("Localizer-Ser")]
        public List<ServiceReadDTO> LocalizeService(List<ServiceReadDTO> services)
        {
            for (int i = 0; i < services.Count; i++)
            {
                services[i].Name = _localizer[services[i].Name].Value;
            }
            return services;
        }


    }
}
