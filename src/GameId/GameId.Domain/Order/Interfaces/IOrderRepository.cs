using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Order.Interface
{
    public interface IOrderRepository
    {
        Order GetById(string id);
        void Add(Order order);
        void SaveChanges();
    }
}
