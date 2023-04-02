namespace Pizza_server.Repositories
{
    public class ClientStorage
    {
        private Dictionary<int, Client> Clients { get; } = new Dictionary<int, Client>();
        //private SqlConnection Connection { get; } = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        //public AuthorStorage() => Connection.Open();

        public Client Create(Client client)
        {
            Clients.Add(client.Id, client);
            return client;
            //var command = Connection.CreateCommand();
            //command.CommandText = "SELECT * FROM .....";
            //command.ExecuteNonQuery
            //command.ExecuteReader
            //command.ExecuteScalar
        }

        public Client Read(int clientId)
        {
            return Clients[clientId];
        }

        public Client Update(int clientId, Client newClient)
        {
            Clients[clientId] = newClient;
            return Clients[clientId];
        }

        public bool Delete(int clientId)
        {
            return Clients.Remove(clientId);
        }
    }
}
