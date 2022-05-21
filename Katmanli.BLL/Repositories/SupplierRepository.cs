using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        NorthwindEntities db = new NorthwindEntities();

        public void Delete(int itemId)
        {
            Supplier deleted = db.Suppliers.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Suppliers.Remove(deleted);
            db.SaveChanges();
        }

        public Supplier Get(int itemId)
        {
            return db.Suppliers.Find(itemId);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public void Insert(Supplier item)
        {
            db.Suppliers.Add(item);
            db.SaveChanges();
        }

        public void Update(Supplier item)
        {
            Supplier updated = db.Suppliers.Find(item.SupplierID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
