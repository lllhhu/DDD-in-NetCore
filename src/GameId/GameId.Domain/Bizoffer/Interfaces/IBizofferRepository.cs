using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Bizoffer.Interface
{
    public interface IBizofferRepository
    {
        Bizoffer GetById(string Id);

        void Add(Bizoffer bizoffer);

        void Update(Bizoffer bizoffer);

    }
}
