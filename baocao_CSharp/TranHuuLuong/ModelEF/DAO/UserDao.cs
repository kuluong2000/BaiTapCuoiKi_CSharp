using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private TranHuuLuongContext db;
        public UserDao()
        {
            db = new TranHuuLuongContext();
        }
        public int login(string user, string pass,string status)
        {
            status = "Activated";
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass) && x.Status.Contains(status));

            if (result == null)
                return 0;
            else
                return 1;
        
    }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
        public IEnumerable<UserAccount> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
        public string Insert(UserAccount entityUser)
        {
            var user = Find(entityUser.UserName);
            if (user == null)
            {
                db.UserAccounts.Add(entityUser);
            }
            else
            {
                user.UserName = entityUser.UserName;
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }

            }

            db.SaveChanges();
            return entityUser.UserName;
        }
        public bool Update(UserAccount entityUser)
        {
            try
            {
                var user = db.UserAccounts.Find(entityUser.UserName);
                user.UserName = entityUser.UserName;
               // if (!string.IsNullOrEmpty(entityUser.Password))
                //{
                user.Password = entityUser.Password;
              //  }
                user.Status = entityUser.Status;
                
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
                var user1 = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user1);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public UserAccount Find(string UserName)
        {
            return db.UserAccounts.Find(UserName);
        }
    }
}
