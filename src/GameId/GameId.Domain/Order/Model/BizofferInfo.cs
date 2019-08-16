using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Order
{
    /// <summary>
    /// 在Order上下文，是一个值对象
    /// </summary>
    public class BizofferInfo
    {
        public BizofferInfo()
        {

        }

        public BizofferInfo(string bizofferId,string name,decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || price < 0)
            {
                throw new ArgumentNullException("参数不能为空");
            }

            this.BizofferId = bizofferId;
            this.Name = name;
            this.Price = price;
   
        }

        /// <summary>
        /// 供应商商品Id
        /// </summary>
        public string BizofferId
        {
            get;private set;
        }

        public string Name
        {
            get;private set;
        }

        public decimal Price
        {
            get;private set;
        }


    }
    
}
