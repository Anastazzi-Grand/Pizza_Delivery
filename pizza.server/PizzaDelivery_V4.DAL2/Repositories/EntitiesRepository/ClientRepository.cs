using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.DAL2.Repositories.Interfaces;
using PizzaDelivery_V4.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL2.Repositories.EntitiesRepository
{
    public class ClientRepository : IClientRepository
    {
        public readonly PDDbContext _db;

        public ClientRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<Client> Add(Client client)
        {
            var result = await _db.Client.AddAsync(client);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Client = await GetById(id);
            _db.Remove(Client);
            await _db.SaveChangesAsync();
            return Client != null ? true : false;
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _db.Client.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _db.Client.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Client GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> Update(Client client)
        {
            var result = _db.Client.Update(client);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<Client> IEntityRepository<Client>.GetByNameEntity(string name)
        {
            return await _db.Client.FirstOrDefaultAsync(p => p.FullName == name);
        }
    }
}
