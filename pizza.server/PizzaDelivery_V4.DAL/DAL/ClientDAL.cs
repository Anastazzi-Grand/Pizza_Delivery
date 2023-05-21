using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class ClientDAL
    {
        private readonly ApplicationContext _db;

        public ClientDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _db.Client.ToListAsync();
        }

        public async Task<Client> Add(Client newClient)
        {
            var client = new Client()
            {
                Id = newClient.Id,
                FullName = newClient.FullName,
                Address = newClient.Address,
                PhoneNumber = newClient.PhoneNumber,
            };

            await _db.Client.AddAsync(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> Get(int id)
        {
            return await _db.Client.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client?> Update(Client client)
        {
            var dbClient = await Get(client.Id);
            if (dbClient != null)
            {
                dbClient.FullName = client.FullName;
                dbClient.PhoneNumber = client.PhoneNumber;
                dbClient.Address = client.Address;

                await _db.SaveChangesAsync();
                return dbClient;
            }
            else
            {
                return null;
            }
        }

        public async Task<Client?> Delete(int id)
        {
            var dbClient = await Get(id);

            if (dbClient != null)
            {
                _db.Client.Remove(dbClient);
                await _db.SaveChangesAsync();
                return dbClient;
            }
            else
            {
                return null;
            }
        }
    }
}
