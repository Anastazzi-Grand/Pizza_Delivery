using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Repositories.EntitiesRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly PDDbContext _db;

        public EmployeeRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<Employee> Add(Employee employee)
        {
            var result = await _db.Employee.AddAsync(employee);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Employee = await GetById(id);
            _db.Remove(Employee);
            await _db.SaveChangesAsync();
            return Employee != null ? true : false;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _db.Employee.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _db.Employee.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Employee GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Update(Employee employee)
        {
            var result = _db.Employee.Update(employee);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<Employee> IEntityRepository<Employee>.GetByNameEntity(string name)
        {
            return await _db.Employee.FirstOrDefaultAsync(p => p.Surname == name);
        }
    }
}
