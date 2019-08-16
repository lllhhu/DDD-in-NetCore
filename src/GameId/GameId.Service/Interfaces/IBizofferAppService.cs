using GameId.Domain.Bizoffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Service.Interface
{
    public interface IBizofferAppService
    {
        string CreateBizoffer(string name, decimal price, string gameId, string gameName, string userId, string userName);
        Bizoffer GetById(string bizofferId);
        string SetStatusToUp(string id);
    }
}
