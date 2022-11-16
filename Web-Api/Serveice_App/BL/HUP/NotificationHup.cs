using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class NotificationHup: Hub
    {
        private readonly IProviderManger _providerManger;
        private readonly ICustomerManager _customerManger;


        public NotificationHup(IProviderManger providerManger, ICustomerManager customerManger)
        {
            _providerManger = providerManger;
            _customerManger = customerManger;
        }

        public async Task CustomerSendNotification(RequestCostemerProviderWriteDTO RequestData)
        {
            var userId = _providerManger.GetByID(RequestData.ProviderId).UserId;
            await Clients.User(userId).SendAsync("ProviderReciveNotification", RequestData);
        }

        public async Task ProviderSendNotification(RequestProviderCustomerWriteDTO RequestData)
        {
            var userId = _customerManger.GetByID(RequestData.CustomerId).UserId;
            await Clients.User(userId).SendAsync("CustomerReciveNotification", RequestData);
        }
    }
}
