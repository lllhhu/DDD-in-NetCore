using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameId.Domain.Bizoffer.Interface;
using GameId.Domain.Events;
using GameId.Domain.Interface;
using MediatR;

namespace GameId.Service
{
    /// <summary>
    /// 事件模式，适用于聚合间或上下文间的通信
    /// 当用户创建发布单时，给卖家发布计数加一（卖家不存在则创建一个Seller）
    /// 这里使用事件处理方式，中介者模式解耦聚合间事务保存
    /// 同一个事务保存两个聚合，异步处理数据不一致处理比较复杂
    /// </summary>
    public class IncrementOrAddSellerWhenBizofferCreatedDomainEventHandler : INotificationHandler<BizofferCreatedDomainEvent>
    {
        private readonly ISellerRepository sellerRepository;
        private readonly IUnitOfWork unitOfWork;

        public IncrementOrAddSellerWhenBizofferCreatedDomainEventHandler(IUnitOfWork unitOfWork,ISellerRepository sellerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.sellerRepository = sellerRepository;
        }

        public Task Handle(BizofferCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var seller = this.sellerRepository.GetSellerById(notification.UserId);
            if (seller == null)
            {
                seller = new Domain.Bizoffer.Seller(notification.UserId,notification.UserName);
                this.sellerRepository.AddSeller(seller);
            }
            seller.PublishIncrement();
            this.unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
