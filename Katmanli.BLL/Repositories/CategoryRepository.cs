using Katmanli.DAL;
using Katmanli.DTO;
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
        public void Insert(CategoryDTO item)       //Category gelmiyorsa Katmanli.DAL'ı referans vermeyi unutmuşsundur.
        {
            Category c = new Category { CategoryName = item.CategoryName, Description = item.Description };
            db.Categories.Add(c);
            db.SaveChanges();
        }

        public void Update(CategoryDTO item)
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

        public List<CategoryDTO> GetAll() 
        {
            List<Category> c = new List<Category>();
            c = db.Categories.ToList();
            List<CategoryDTO> cDTOList = new List<CategoryDTO>();
            foreach (var item in c)
            {
                cDTOList.Add(new CategoryDTO { CategoryID=item.CategoryID,CategoryName=item.CategoryName,Description=item.Description });
            }
            return cDTOList;
        } 

        public CategoryDTO Get(int itemId)
        {
            CategoryDTO cDTO = new CategoryDTO();
            List<Category> c = new List<Category>();
            c.Add(db.Categories.Find(itemId));
            foreach (var item in c)
            {
                cDTO.CategoryID = item.CategoryID;
                cDTO.CategoryName = item.CategoryName;
                cDTO.Description = item.Description;
            }
            return cDTO;
        }
    }
}
