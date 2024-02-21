using MicroserviceProduct.Models;

namespace MicroserviceProduct.DBQueries
{
    public interface IClients_Query
    {
        public Client? GetClient(int clientId);

        public bool InsertClient(Client client);
    }
}
