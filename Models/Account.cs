using System;
using System.Collections.Generic;

namespace MicroserviceProduct.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal SavedMontlyAmount { get; set; }
        public int NumbeOfPeriods { get; set; }
        public decimal InterestRate { get; set; }

        public virtual Client User { get; set; } = null!;
    }
}
