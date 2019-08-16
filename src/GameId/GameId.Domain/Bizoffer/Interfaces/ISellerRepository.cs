using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Bizoffer.Interface
{
    public interface ISellerRepository
    {
        Seller GetSellerById(string userId);
        void AddSeller(Seller seller);
    }
}
