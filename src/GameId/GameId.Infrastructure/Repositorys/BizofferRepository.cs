using GameId.Domain.Bizoffer;
using GameId.Domain.Bizoffer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Infrastructure.Repository
{
    public class BizofferRepository : IBizofferRepository
    {
        private readonly AppContext appContext = null;

        public BizofferRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }


        public void Add(Bizoffer bizoffer)
        {
            this.appContext.Bizoffer.Add(bizoffer);
        }

        public Bizoffer GetById(string Id)
        {
            return this.appContext.Bizoffer.Find(Id);
        }


        public void Update(Bizoffer bizoffer)
        {
            throw new NotImplementedException();
        }
    }
}
