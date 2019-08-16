using GameId.Domain.Interface;
using GameId.Domain.Order.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Order
{
    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IBizofferService bizofferService;
        private readonly ISecurityService securityService;

        public PlaceOrderService(IOrderRepository orderRepository, IBizofferService bizofferService,ISecurityService securityService)
        {
            this.orderRepository = orderRepository;
            this.bizofferService = bizofferService;
            this.securityService = securityService;
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="bizofferId"></param>
        /// <param name="buyerId"></param>
        /// <param name="buyerName"></param>
        /// <returns></returns>
        public Order Execute(string bizofferId, string buyerId, string buyerName)
        {
            //调用风控服务，是否是黑名单用户
            var IsExistsBlackList =  this.securityService.IsExistsBlackList(buyerId);
            if (IsExistsBlackList) throw new Exception("该用户是黑名单用户"); //领域层里所有业务检查都抛出异常的方式处理，否则应用服务层要有if判断语句

            //调用发布单上下文获取发布单信息
            BizofferInfo bizofferInfo = this.bizofferService.GetBizofferInfoById(bizofferId);

            //创建订单
            var order = new Order(buyerId,buyerName);
            order.AddItem(bizofferInfo);

            return order;
        }

    }
}
