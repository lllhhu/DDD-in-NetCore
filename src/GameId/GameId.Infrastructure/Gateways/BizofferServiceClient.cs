using GameId.Domain.Order;
using GameId.Domain.Order.Interface;
using GameId.Service;
using GameId.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Infrastructure.Gateway
{
    /// <summary>
    /// 调用Bizoffer上下文
    /// 使用防腐层的方式处理
    /// </summary>
    public class BizofferServiceClient : IBizofferService
    {
        private readonly IBizofferAppService bizofferAppService;
        public BizofferServiceClient(IBizofferAppService bizofferAppService)
        {
            this.bizofferAppService = bizofferAppService;
        }

        public BizofferInfo GetBizofferInfoById(string bizofferId)
        {
            //处理两个上下文模型不匹配问题
            //在这里处理不会影响到当前上下文
            //起到一个防腐层功能
            var bizoffer = this.bizofferAppService.GetById(bizofferId);
            var bizofferInfo = new BizofferInfo(bizoffer.Id,bizoffer.Name,bizoffer.Price);
            return bizofferInfo;
        }
    }
}
