using GameId.Domain.Order;
using GameId.Domain.Order.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppContext appContext = null;

        public OrderRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public void Add(Order order)
        {
            this.appContext.Order.Add(order);
        }

        public Order GetById(string id)
        {
            return this.appContext.Order.Find(id);
        }

        public void SaveChanges()
        {
            this.appContext.SaveChanges();
        }
    }
}
