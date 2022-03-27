using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data
{
    public class MortgageDbDetails : IMortgageDbDetails
    {
        private readonly MortgageDbContext _db;

        public MortgageDbDetails(MortgageDbContext db)
        {
            _db = db;
        }   
       
        List<Entity.Mortgage> IMortgageDbDetails.GetAllMortages()
        {
            return _db.Mortgages.ToList();
        }
    }
}
