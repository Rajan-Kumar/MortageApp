using Mortgage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mortgage.Data.Entity;
using Mortgage.Data;

namespace Mortgage.Services.Implementation
{
    public class MortgageDetails : IMortgageDetails
    {
        private readonly Mortgage.Data.IMortgageDbDetails _mortgageDbDetails;

        public MortgageDetails(IMortgageDbDetails mortgageDbDetails)
        {
            _mortgageDbDetails = mortgageDbDetails ?? throw new ArgumentNullException(nameof(mortgageDbDetails));
        }

        public List<Mortgage.Data.Entity.Mortgage> GetAllMortages()
        {
            return _mortgageDbDetails.GetAllMortages();
        }       
    }
}
