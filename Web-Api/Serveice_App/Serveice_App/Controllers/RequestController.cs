using AutoMapper;
using BL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Serveice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestManger _requestManger;
        private readonly IProviderManger _providerManger;
        private readonly ICustomerManager _customerManager;
        private readonly IMapper _mapper;
        public RequestController(IRequestManger requestManger, IProviderManger providerManger, ICustomerManager customerManager, IMapper mapper)
        {
            _requestManger = requestManger;
            _providerManger = providerManger;
            _customerManager = customerManager;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("CustomerSendRequest")]
        public ActionResult CustomerSendRequest(RequestCostemerProviderWriteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provider = _providerManger.GetByID(model.ProviderId);
            var customer = _customerManager.GetByID(model.CustomerId);
            if (provider is null || customer is null)
                return BadRequest();

            _requestManger.Add(model);
            return Ok();
        }

        // Provider Accepts Request
        [HttpPost]
        [Route("ProviderSendOffer")]
        public ActionResult ProviderSendOffer(RequestProviderCustomerWriteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provider = _providerManger.GetByID(model.ProviderId);
            var customer = _customerManager.GetByID(model.CustomerId);
            if (provider is null || customer is null)
                return BadRequest();

            _requestManger.Update(model);
            return Ok();
        }
        //Provider Rejects Request
        [HttpPost]
        [Route("ProviderRejectOffer")]
        public ActionResult ProviderRejectOffer(RequestRejectWriteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provider = _providerManger.GetByID(model.ProviderId);
            var customer = _customerManager.GetByID(model.CustomerId);
            if (provider is null || customer is null)
                return BadRequest();


            var UpdateModel = _mapper.Map<RequestUpdateStateWriteDTO>(model);
            UpdateModel.State = stateType.ProviderReject;
            _requestManger.UpdateState(UpdateModel);
            return Ok(model.Message);
        }


    }
}
