using GameId.Domain.Interface;
using GameId.Domain.Order;
using GameId.Domain.Order.Interface;
using GameId.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Service
{
    public class OrderAppService: IOrderAppService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IPlaceOrderService placeOrderService;
        private readonly IUnitOfWork unitOfWork;

        public OrderAppService(IOrderRepository orderRepository, IPlaceOrderService placeOrderService, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.placeOrderService = placeOrderService;
            this.unitOfWork = unitOfWork;

        }

        /// <summary>
        /// 支付成功回调处理
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string PayedOrder(string orderId)
        {
            try
            {
                var order = this.orderRepository.GetById(orderId);
                order.SetStatusToHadPay();//设置为已付款

                this.orderRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                //处理异常，包括领域层返回的异常
                Console.WriteLine(ex);
                return "fail";
            }
            return "ok";
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="bizofferId"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string PlaceOrder(string bizofferId, string userId, string userName)
        {
            try
            {
                //调用下单领域服务下单
                var order = this.placeOrderService.Execute(bizofferId, userId, userName);

                this.orderRepository.Add(order);
                this.unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                //处理异常，包括领域层返回的异常
                Console.WriteLine(ex);
                return "fail";
            }
            return "ok";
        }
    }
}
