using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class EmployeeDAL
    {
        private readonly ApplicationContext _db;

        public EmployeeDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _db.Employee.ToListAsync();

        }

        public async Task<Employee> Add(Employee newEmployee)
        {
            var dbEmployee = new Employee()
            {
                Id = newEmployee.Id,
                Surname = newEmployee.Surname,
                PhoneNumber = newEmployee.PhoneNumber,
                Position = newEmployee.Position,
        };

            await _db.Employee.AddAsync(dbEmployee);
            await _db.SaveChangesAsync();
            return dbEmployee;
        }

        public async Task<Employee?> Get(int id)
        {
            return await _db.Employee.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee?> Update(Employee employee)
        {
            var dbEmployee = await Get(employee.Id);
            if (dbEmployee != null)
            {
                dbEmployee.Surname = employee.Surname;
                dbEmployee.PhoneNumber = employee.PhoneNumber;
                dbEmployee.Position = employee.Position;

                await _db.SaveChangesAsync();
                return dbEmployee;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee?> Delete(int id)
        {
            var dbEmployee = await Get(id);

            if (dbEmployee != null)
            {
                _db.Employee.Remove(dbEmployee);
                await _db.SaveChangesAsync();
                return dbEmployee;
            }
            else
            {
                return null;
            }
        }
    }
}
