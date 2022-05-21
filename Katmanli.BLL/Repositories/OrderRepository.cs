using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Order deleted = db.Orders.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Orders.Remove(deleted);
            db.SaveChanges();
        }

        public Order Get(int itemId)
        {
            return db.Orders.Find(itemId);
        }

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void Insert(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public void Update(Order item)
        {
            Order updated = db.Orders.Find(item.OrderID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
