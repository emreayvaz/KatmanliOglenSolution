using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Employee deleted = db.Employees.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Employees.Remove(deleted);
            db.SaveChanges();
        }

        public Employee Get(int itemId)
        {
            return db.Employees.Find(itemId);
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public void Insert(Employee item)
        {
            db.Employees.Add(item);
            db.SaveChanges();
        }

        public void Update(Employee item)
        {
            Employee updated = db.Employees.Find(item.EmployeeID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
