using GameId.Domain.Events;
using GameId.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Bizoffer
{
    public enum PublishStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        Initial = 1,
        /// <summary>
        /// 发布成功
        /// </summary>
        Published = 2,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause = 3,
        /// <summary>
        /// 审核失败
        /// </summary>
        AuditFailed = 4,
        /// <summary>
        /// 停止出售
        /// </summary>
        Stop = 5,
        /// <summary>
        /// 交易成功
        /// </summary>
        Succeed = 6,
        /// <summary>
        /// 已支付
        /// </summary>
        Payed = 7
    }

    public class Bizoffer:Entity
    {
        /// <summary>
        /// 每个实体，写一个无参构造函数，便于从数据库重建对象时构造实体
        /// 如果没有无参构造函数，那么会执行已定义的有参构造函数，就会导致其他副作用，如下面有参构造函数
        /// 中有创建实体时添加的领域事件，就会导致每次查找实体时发送事件
        /// </summary>
        public Bizoffer()
        {
        }

        public Bizoffer(string name, decimal price, string gameId, string gameName,string userId,string userName)
        {
            if (price <= 0)
            {
                throw new Exception("发布单金额不能等于小于零");
            }
            this.Name = name;
            this.Price = price;
            this.GameId = gameId;
            this.GameName = gameName;
            this.Status = PublishStatus.Initial;
            this.UserId = userId;
            this.UserName = userName;
            this.AddDomainEvent(new BizofferCreatedDomainEvent(this.UserId,this.UserName));
        }

        public string Id
        {
            get;private set;
        }

        public string Name
        {
            get; private set;
        }

        public decimal Price
        {
            get; private set;
        }

        public string GameId
        {
            get; private set;
        }

        public string GameName
        {
            get; private set;
        }

        public string GameAccount
        {
            get; private set;
        }

        public string GamePassword
        {
            get; private set;
        }

        public string GameInfo
        {
            get; private set;
        }

        public PublishStatus Status
        {
            get; private set;
        }

        public string UserId
        {
            get;private set;
        }

        public string UserName
        {
            get;private set;
        }

        public void setStatusToUp()
        {
            //如果修改状态之前有逻辑就写在这里
            this.Status = PublishStatus.Published;
        }

        public void setStatusToDown()
        {
            //如果修改状态之前有逻辑就写在这里
            this.Status = PublishStatus.Stop;
        }
        



    }
}
