using MicroserviceProduct.Calculations;
using MicroserviceProduct.DBContexts;
using MicroserviceProduct.Models;

namespace MicroserviceProduct.DBQueries
{
    public class Accounts_Queries : IAccounts_Queries
    {
        MicroserviceProductContext _context;
        ILogger _logger;
        public Accounts_Queries(MicroserviceProductContext context,
                                ILogger logger) 
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Query for the account info given the client id
        /// </summary>
        /// <param name="clientId">client id</param>
        /// <returns>Account Info</returns>
        internal Account? GetAccount(int clientId)
        {
           return _context.Accouts.Where(a => a.UserId == clientId).FirstOrDefault();
        }

        public List<MoneyByPeriod> GetFutureValueOfMoney(int clientId)
        {
            Account account = GetAccount(clientId);
            return FutureValueOfMoney.MoneyByNumPeriods(account.NumbeOfPeriods,
                                                        account.SavedMontlyAmount,
                                                        account.InterestRate);
        }

        public bool InsertAccount(UR_Account account)
        {
            try
            {
                Account regAccount = new Account()
                {
                    UserId = account.UserId,
                    SavedMontlyAmount = account.SavedMontlyAmount,
                    NumbeOfPeriods = account.NumbeOfPeriods,
                    InterestRate = account.InterestRate
                };
                Client client = _context.Clients.FirstOrDefault(c => c.Id == account.UserId);
                regAccount.User = client;
                _context.Add(regAccount);
                _context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
