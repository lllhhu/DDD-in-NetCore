using GameId.Domain.Bizoffer;
using GameId.Domain.Bizoffer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Infrastructure.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AppContext appContext = null;

        public SellerRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public void AddSeller(Seller seller)
        {
            this.appContext.Seller.Add(seller);
        }

        public Seller GetSellerById(string userId)
        {
            return this.appContext.Seller.Find(userId);
        }
    }
}
