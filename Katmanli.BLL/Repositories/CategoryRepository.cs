using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.Repositories
{
    public class CategoryRepository
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Insert(Category item)       //Category gelmiyorsa Katmanli.DAL'ı referans vermeyi unutmuşsundur.
        {
            db.Categories.Add(item);
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            Category updated = db.Categories.Find(item.CategoryID);
            db.Entry(updated).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public void Delete(int itemId)
        {
            Category deleted = db.Categories.Find(itemId);  //id değerini bulur ve o satırın değerlerini alır.
            db.Categories.Remove(deleted);
            db.SaveChanges();
        }

        public List<Category> GetAll() 
        {
            return db.Categories.ToList();
        } 

        public Category Get(int itemId)
        {
            return db.Categories.Find(itemId);
        }
    }
}
