using Katmanli.BLL.IRepository;
using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Product deleted = db.Products.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Products.Remove(deleted);
            db.SaveChanges();
        }

        public Product Get(int itemId)
        {
            return db.Products.Find(itemId);
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public void Insert(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public void Update(Product item)
        {
            Product updated = db.Products.Find(item.ProductID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
