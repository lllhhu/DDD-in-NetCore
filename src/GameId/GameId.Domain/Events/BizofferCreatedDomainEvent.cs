using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Events
{
    /// <summary>
    /// 发布单提交数据库前发布该事件，订阅的处理器可以收到此事件
    /// </summary>
    public class BizofferCreatedDomainEvent: INotification
    {
        public BizofferCreatedDomainEvent(string userId,string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }

        public string UserId
        {
            get; private set;
        }

        public string UserName
        {
            get; private set;
        }
    }
}
