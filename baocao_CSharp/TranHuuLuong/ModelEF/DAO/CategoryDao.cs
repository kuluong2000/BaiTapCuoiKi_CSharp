using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private TranHuuLuongContext db;
        public CategoryDao()
        {
            db = new TranHuuLuongContext();
        }
        public List<Category> ListNewCate(int number)
        {
            return db.Categories.OrderByDescending(x => x.Name).Take(number).ToList();
        }
        public List<Category> ListFeatureCategory(int status)
        {
            return db.Categories.Where(x => x.Name != null).Take(status).ToList();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        //tim kiem
        public IEnumerable<Category> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
       
        public string Insert(Category enity)
        {
            db.Categories.Add(enity);
            db.SaveChanges();
            return enity.CategoryID;
        }
        public bool Update(Category entity)
        {
            try
            {
                var cateID = Find(entity.CategoryID);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    cateID.Name = entity.Name;
                }
                if (entity.CategoryID == null)
                {
                    cateID.CategoryID = entity.CategoryID;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Delete(string id)
        {
            try
            {
                var result = db.Categories.Where(x => x.CategoryID==id).SingleOrDefault();
                db.Categories.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Category Find(string CategoryID)
        {
            
            return db.Categories.Where(x => x.CategoryID.Equals(CategoryID)).SingleOrDefault();
        }
       
    }
}
