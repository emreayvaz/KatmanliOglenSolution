using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    class OrderDetailRepository : IRepository<Order_Detail>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Order_Detail deleted = db.Order_Details.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Order_Details.Remove(deleted);
            db.SaveChanges();
        }

        public Order_Detail Get(int itemId)
        {
            return db.Order_Details.Find(itemId);
        }

        public List<Order_Detail> GetAll()
        {
            return db.Order_Details.ToList();
        }

        public void Insert(Order_Detail item)
        {
            db.Order_Details.Add(item);
            db.SaveChanges();
        }

        public void Update(Order_Detail item)
        {
            Order_Detail updated = db.Order_Details.Find(item.OrderID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
