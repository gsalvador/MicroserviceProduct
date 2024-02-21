using MicroserviceProduct.DBContexts;
using MicroserviceProduct.Models;

namespace MicroserviceProduct.DBQueries
{
    public class Clients_Query : IClients_Query
    {
        MicroserviceProductContext _context;
        ILogger _logger;
        public Clients_Query(MicroserviceProductContext context,
                            ILogger logger) 
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Returns Client info, given client Id (cédula)
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <returns>Client Info</returns>
        public Client? GetClient(int clientId)
        {
            return _context.Clients.Where(c => c.Id == clientId).FirstOrDefault();
        }

        /// <summary>
        /// Insert client in the database
        /// </summary>
        /// <param name="client">Client to be inserted</param>
        /// <returns>True if operation is successful</returns>
        public bool InsertClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                // Log error
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
