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

        bool IMortgageDbDetails.AddMortgage(Entity.Mortgage mortgage)
        {
            try
            {
                _db.Mortgages.Add(mortgage);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        List<Entity.Mortgage> IMortgageDbDetails.GetAllMortages()
        {
            return _db.Mortgages.ToList();
        }
    }
}
