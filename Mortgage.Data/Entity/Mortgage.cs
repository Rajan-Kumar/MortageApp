using Mortgage.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data.Entity
{
    public class Mortgage
    {
        [Key]
        public int MortgageId { get; set; }
        [Required]
        public string Name { get; set; }
        public MortgageType MortgageType { get; set; }
        public InterestRepayment InterestRepayment { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; internal set; }
    }
}
