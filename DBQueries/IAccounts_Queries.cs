using MicroserviceProduct.Models;

namespace MicroserviceProduct.DBQueries
{
    public interface IAccounts_Queries
    {
        public List<MoneyByPeriod> GetFutureValueOfMoney(int clientId);
        public bool InsertAccount(UR_Account account);
    }
}
