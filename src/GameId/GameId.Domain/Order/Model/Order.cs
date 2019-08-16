using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameId.Domain.Order
{
    //订单状态
    public enum OrderStatus
    {
        /// <summary>
        /// 等待付款（前台下单未支付未取消）
        /// </summary>
        WaitPaying = 1,
        /// <summary>
        /// 已付款（下单已支付未取消）
        /// </summary>

        HadPay = 2,
        /// <summary>
        /// 待发货（物服更改）
        /// </summary>

        WaiDelivery = 3,
        /// <summary>
        /// 已发货 等待转账
        /// </summary>

        HadDeliveryWaitForTransfer = 4,
        /// <summary>
        /// 结单 交易完成
        /// </summary>

        Check = 5,
        /// <summary>
        /// 已退款
        /// </summary>

        HadRefund = 6,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancel = 7,
        /// <summary>
        /// 发货失败等待退款
        /// </summary>
        DeliveryFailedWaitForDrawback = 8,
    }

    public class Order
    {
        public Order()
        { }

        public Order(string buyerId, string buyerName)
        {
            this.Id = Guid.NewGuid().ToString();
            this.BuyerId = buyerId;
            this.BuyName = buyerName;
            this.OrderItems = new List<OrderItem>();
            this.SetStatusToWaitPaying();
        }

        public string Id
        {
            get;private set;
        }

        public string Name
        {
            get;private set;
        }

        public decimal TotalPrice
        {
            get;private set;
        }

        public string BuyerId
        {
            get;private set;
        }

        public string BuyName
        {
            get;private set;
        }

        public OrderStatus Status
        {
            get;private set;
        }

        public virtual ICollection<OrderItem> OrderItems
        {
            get; private set;
        }

        public void AddItem(BizofferInfo info)
        {
            if (info == null) throw new Exception("发布单信息不能为空");
            if (info.Price <= 0) throw new Exception("发布单价格不能小于等于0");

            //由于order和orderItem是个聚合关系,order是这个聚合的聚合根，它负责业务规则的不变性和数据的一致性
            //下面逻辑体现了以上原则

            this.TotalPrice = this.TotalPrice + info.Price;//数据的一致性

          
            var items = this.OrderItems.Where(m=>m.BizofferInfo.BizofferId == info.BizofferId).ToList();   //业务的不变性，如果订单项列表中已有该商品，则订单项商品数加一即可
            if (items.Count > 0)
            {
                items[0].IncrementQuantity();
            }
            else
            {

                OrderItem item = new OrderItem(info);
                this.OrderItems.Add(item);
            }


        }

        //设置状态为等待付款
        public void SetStatusToWaitPaying()
        {
            this.Status = OrderStatus.WaitPaying;
        }

        //设置状态为已支付
        public void SetStatusToHadPay()
        {
            //如果有逻辑写在这里
            this.Status = OrderStatus.HadPay;
        }


    }
}
