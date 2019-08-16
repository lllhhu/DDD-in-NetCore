using System;
using System.Collections.Generic;
using System.Text;
using GameId.Domain.Bizoffer;
using GameId.Domain.Bizoffer.Interface;
using GameId.Domain.Interface;
using GameId.Service.Interface;

namespace GameId.Service
{
    public class BizofferAppService:IBizofferAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBizofferRepository bizofferRepository;

        public BizofferAppService(IUnitOfWork unitOfWork, IBizofferRepository bizofferRepository)
        {
            this.unitOfWork = unitOfWork;
            this.bizofferRepository = bizofferRepository;
        }


        public string CreateBizoffer(string name, decimal price, string gameId, string gameName,string userId,string userName)
        {

            try
            {
                GameId.Domain.Bizoffer.Bizoffer bizoffer = new Domain.Bizoffer.Bizoffer(name, price, gameId, gameName,userId,userName);
                this.bizofferRepository.Add(bizoffer);
                this.unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                //处理异常，包括领域层返回的异常
                Console.WriteLine(ex);
                return "fail";
            }


            return "ok";
        }

        public Bizoffer GetById(string bizofferId)
        {
            var bizoffer = bizofferRepository.GetById(bizofferId);
            return bizoffer;
        }

        public string SetStatusToUp(string id)
        {
            try
            {
                var bizoffer = bizofferRepository.GetById(id);
                bizoffer.setStatusToUp();
                this.bizofferRepository.Update(bizoffer);
                this.unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                //处理异常，包括领域层返回的异常
                Console.WriteLine(ex);
                return "fail";
            }
            return "ok";
        }

    }
}
