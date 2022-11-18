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
        [Route("ProviderRejectRequest")]
        public ActionResult ProviderRejectRequest(RequestmessageWriteDTO model)
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

        //Customer Reject offer
        [HttpPost]
        [Route("CustomerRejectOffer")]
        public ActionResult CustomerRejectOffer(RequestmessageWriteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provider = _providerManger.GetByID(model.ProviderId);
            var customer = _customerManager.GetByID(model.CustomerId);
            if (provider is null || customer is null)
                return BadRequest();


            var UpdateModel = _mapper.Map<RequestUpdateStateWriteDTO>(model);
            UpdateModel.State = stateType.CustomerReject;
            _requestManger.UpdateState(UpdateModel);
            return Ok(model.Message);
        }

        //Customer acsept offer
        [HttpPost]
        [Route("CustomerAcceptOffer")]
        public ActionResult CustomerAcceptOffer(RequestmessageWriteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provider = _providerManger.GetByID(model.ProviderId);
            var customer = _customerManager.GetByID(model.CustomerId);
            if (provider is null || customer is null)
                return BadRequest();


            var UpdateModel = _mapper.Map<RequestUpdateStateWriteDTO>(model);
            UpdateModel.State = stateType.Acceptted;
            _requestManger.UpdateState(UpdateModel);
            return Ok(model.Message);
        }

        //get all request for customer
        [HttpGet]
        [Route("CustomerAllRequest/{CustomerId:Guid}")]
        public ActionResult<List<RequestReadDTO>> CustomerAllRequest(Guid CustomerId)
        {
            var result = _requestManger.GetCustomerRequests(CustomerId);
            if (result==null)
            {
                return BadRequest("No data");
            }
            return result;
        }

        //get all request for provider
        [HttpGet]
        [Route("ProviderAllRequest/{ProviderId:Guid}")]
        public ActionResult<List<RequestReadDTO>> ProviderAllRequest(Guid ProviderId)
        {
            var result = _requestManger.GetProviderRequests(ProviderId);
            if (result == null)
            {
                return BadRequest("No data");
            }
            return result;
        }

        [HttpGet]
        [Route("GetRequest/{RequestId:Guid}")]
        public ActionResult<RequestReadDTO> GetRequest(Guid RequestId)
        {
            var result = _requestManger.GetByID(RequestId);
            if (result == null)
            {
                return BadRequest("no Data");
            }
            return result;
        }

        [HttpGet]
        [Route("CountProviderAllRequest/{ProviderId:Guid}")]
        public ActionResult<int> CountProviderAllRequest(Guid ProviderId)
        {
            var result = _requestManger.GetProviderRequests(ProviderId);
            if (result == null)
            {
                return BadRequest("No data");
            }
            return result.Count;
        }

        [HttpGet]
        [Route("CountCustomerAllRequest/{CustomerId:Guid}")]
        public ActionResult<int> CountCustomerAllRequest(Guid CustomerId)
        {
            var result = _requestManger.GetCustomerRequests(CustomerId);
            if (result == null)
            {
                return BadRequest("No data");
            }
            return result.Count;
        }
    }
}