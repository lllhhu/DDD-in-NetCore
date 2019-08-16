using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Order.Interface
{
    public interface IPlaceOrderService
    {
        Order Execute(string bizofferId,string buyerId,string buyerName);
    }
}
