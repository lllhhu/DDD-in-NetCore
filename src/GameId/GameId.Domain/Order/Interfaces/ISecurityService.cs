using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameId.Domain.Order.Interface
{
    public interface ISecurityService
    {
        bool IsExistsBlackList(string userId);
    }
}
