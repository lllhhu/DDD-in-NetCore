using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Service.Interface
{

    public interface IOrderAppService
    {
        string PlaceOrder(string bizofferId,string userId,string userName);

        string PayedOrder(string orderId);
    }
}
