using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mortgage.Data.Entity;

namespace Mortgage.Services.Interfaces
{
    public interface IMortgageDetails
    {
        List<Mortgage.Data.Entity.Mortgage> GetAllMortages();
        bool AddMortgage(Mortgage.Data.Entity.Mortgage mortgage);
    }
}
