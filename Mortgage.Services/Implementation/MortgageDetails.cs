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

        public List<Data.Entity.Mortgage> ApplySorting(List<Data.Entity.Mortgage> listMortgage, string sortString)
        {
            switch (sortString)
            {
                case "Name":
                    listMortgage= listMortgage.OrderByDescending(x => x.Name).ToList();
                    break;
                case "MortgageType":
                    listMortgage = listMortgage.OrderByDescending(x => x.MortgageType).ToList();
                    break;
                case "InterestRepayment":
                    listMortgage = listMortgage.OrderByDescending(x => x.InterestRepayment).ToList();
                    break;
                case "EffectiveStartDate":
                    listMortgage = listMortgage.OrderByDescending(x => x.EffectiveStartDate).ToList();
                    break;
                case "EffectiveEndDate":
                    listMortgage = listMortgage.OrderByDescending(x => x.EffectiveEndDate).ToList();
                    break;
                case "TermsInMonths":
                    listMortgage = listMortgage.OrderByDescending(x => x.TermsInMonths).ToList();
                    break;
                case "CancellationFee":
                    listMortgage = listMortgage.OrderByDescending(x => x.CancellationFee).ToList();
                    break;
                case "EstablishmentFee":
                    listMortgage = listMortgage.OrderByDescending(x => x.EstablishmentFee).ToList();
                    break;
                default:
                    listMortgage = listMortgage.OrderByDescending(x => x.MortgageId).ToList();
                    break;

            }
            return listMortgage;
        }

        public List<Mortgage.Data.Entity.Mortgage> GetAllMortages()
        {
            return _mortgageDbDetails.GetAllMortages();
        }

        bool IMortgageDetails.AddMortgage(Mortgage.Data.Entity.Mortgage mortgage)
        {
            return _mortgageDbDetails.AddMortgage(mortgage);
        }
    }
}
