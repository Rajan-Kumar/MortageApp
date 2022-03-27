using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data
{
    public interface IMortgageDbDetails
    {
        List<Entity.Mortgage> GetAllMortages();
        bool AddMortgage(Entity.Mortgage mortgage);
    }
}
