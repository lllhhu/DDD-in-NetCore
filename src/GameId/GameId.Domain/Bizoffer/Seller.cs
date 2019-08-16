using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Bizoffer
{
    public class Seller
    {
        public Seller()
        {
        }

        public Seller(string id,string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id
        {
            get;private set;
        }

        public string Name
        {
            get;private set;
        }

        public int PublishCount
        {
            get;private set;
        }

        /// <summary>
        /// 发布单发布计数
        /// </summary>
        public void PublishIncrement(int count=1)
        {
            if (count <= 0) throw new ArgumentNullException("发布数量不能小于0");
            this.PublishCount = this.PublishCount+ count;
        }
    }
}
