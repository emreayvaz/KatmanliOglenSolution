using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class ShipperRepository : IRepository<Shipper>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Shipper deleted = db.Shippers.Find(itemId);
            db.Shippers.Remove(deleted);
            db.SaveChanges();
        }

        public Shipper Get(int itemId)
        {
            return db.Shippers.Find(itemId);
        }

        public List<Shipper> GetAll()
        {
            return db.Shippers.ToList();
        }

        public void Insert(Shipper item)
        {
            db.Shippers.Add(item);
            db.SaveChanges();
        }

        public void Update(Shipper item)
        {
            Shipper updated = db.Shippers.Find(item.ShipperID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
