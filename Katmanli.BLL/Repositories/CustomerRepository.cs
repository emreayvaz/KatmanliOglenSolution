using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Customer deleted = db.Customers.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Customers.Remove(deleted);
            db.SaveChanges();
        }

        public Customer Get(int itemId)
        {
            return db.Customers.Find(itemId);
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public void Insert(Customer item)
        {
            db.Customers.Add(item);
            db.SaveChanges();
        }

        public void Update(Customer item)
        {
            Customer updated = db.Customers.Find(item.CustomerID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
