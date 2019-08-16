using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Order.Interface
{
    public interface IBizofferService
    {
        BizofferInfo GetBizofferInfoById(string bizofferId);
    }
}
