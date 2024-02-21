namespace MicroserviceProduct.Models
{
    public class UR_Account
    {
        public int UserId { get; set; }
        public decimal SavedMontlyAmount { get; set; }
        public int NumbeOfPeriods { get; set; }
        public decimal InterestRate { get; set; }
    }
}
