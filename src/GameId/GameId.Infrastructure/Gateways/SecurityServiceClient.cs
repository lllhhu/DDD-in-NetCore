using GameId.Domain.Order.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameId.Infrastructure.Gateway
{
    /// <summary>
    /// 进程间通信
    /// </summary>
    public class SecurityServiceClient : ISecurityService
    {
        private readonly IHttpClientFactory clientFactory;

        //public SecurityServiceClient(IHttpClientFactory clientFactory)
        //{
        //    this.clientFactory = clientFactory;
        //}

        /// <summary>
        ///调用第三方接口
        //在这里可以做防腐处理，通讯协议，返回数据类型转换等
        //调用失败重试等技术策略，不影响领域逻辑层
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsExistsBlackList(string userId)
        {

            HttpClient httpClient = clientFactory.CreateClient();

            var ExistsBlackList =  httpClient.GetAsync("http://www.baidu.com");
            return ExistsBlackList.Result.ToString() != null ? true : false;
        }
    }
}
