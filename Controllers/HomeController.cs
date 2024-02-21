using MicroserviceProduct.DBContexts;
using MicroserviceProduct.DBQueries;
using MicroserviceProduct.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceProduct.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        private MicroserviceProductContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MicroserviceProductContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public Client? GetClient(string clientId)
        {
            var clientQuery = new Clients_Query(_context, _logger);
            Client? result = null;

            if (string.IsNullOrEmpty(clientId)) 
            {
                return null;
            }
            int clientIdentification; 
            if (!int.TryParse(clientId,out clientIdentification))
            {
                return null;
            }
            try
            {
                result = clientQuery.GetClient(clientIdentification);
            } catch (Exception ex)
            {
                // Log error
                _logger.LogError(ex.Message);
            }
            return result;
        }
        
        [HttpPost]
        [Route("InsertClient")]
        public bool InsertClient([FromBody]Client? client)
        {
            if (client != null) 
            {
                var clientQuery = new Clients_Query(_context, _logger);
                return clientQuery.InsertClient(client);
            }
            return false;
        }

        [HttpPost]
        [Route("InsertAccount")]
        public bool InsertAccount([FromBody]UR_Account? account)
        {
            if (account != null)
            {
                var accountQuery = new Accounts_Queries(_context, _logger);
                return accountQuery.InsertAccount(account);
            }
            return false;
        }


        [HttpGet]
        [Route("GetProyectedIncome")]
        public List<MoneyByPeriod> GetProyectedIncome(string clientId)
        {
            var result = new List<MoneyByPeriod>();
            var accountQuery = new Accounts_Queries(_context, _logger);

            if (string.IsNullOrEmpty(clientId))
            {
                return null;
            }
            int clientIdentification;
            if (!int.TryParse(clientId, out clientIdentification))
            {
                return null;
            }
            try
            {
                result = accountQuery.GetFutureValueOfMoney(clientIdentification);
            }
            catch (Exception ex)
            {
                // Log error
                _logger.LogError(ex.Message);
            }
            return result;
        }
    }
}
