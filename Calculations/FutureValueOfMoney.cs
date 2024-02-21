using MicroserviceProduct.Models;

namespace MicroserviceProduct.Calculations
{
    public static class FutureValueOfMoney
    {
        /// <summary>
        /// Calculate the future value of investment
        /// </summary>
        /// <param name="periods">Number of periods</param>
        /// <param name="savedMontlyAmmount">Montly amount of money depossited</param>
        /// <param name="interestRate">Anual interest rate aplied</param>
        /// <returns>List with the amount of money earn on each period</returns>
        public static List<MoneyByPeriod> MoneyByNumPeriods (int periods, decimal savedMontlyAmmount, decimal interestRate)
        {
            List<MoneyByPeriod> result = new List<MoneyByPeriod>();
            decimal moneyAccumulated =0, moneyAtPeriod;
            for(int i = 1; i <= periods; i++)
            {
                moneyAtPeriod = savedMontlyAmmount * (1 + interestRate / 100);
                moneyAccumulated += moneyAtPeriod;
                MoneyByPeriod mbp = new MoneyByPeriod { Period = i, Money = moneyAccumulated };
                result.Add(mbp);
            }
            return result;
        }
    }
}
