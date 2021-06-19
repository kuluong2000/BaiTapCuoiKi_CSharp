using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            
            var model = user.ListAll();

            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        /*[HttpGet]
        public ActionResult Create()
        {
            return View();

        }*/
        [HttpGet]
        public ActionResult Create(string id)
        {
            var dao = new UserDao();
            var result = dao.Find(id);
            if (result != null)
                return View(result);
            return View();


        }
        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Password))
                    {
                        SetAlert("Không được để mật khẩu trống", "warning");
                        return View();
                    }
                    var dao = new UserDao();

                    if (dao.Find(model.UserName) != null)
                    {
                        SetAlert("Tên người dùng đã tồn tại", "warning");
                        return RedirectToAction("Create", "User");
                    }
                    var pass = Encryptor.EncryptMD5(model.Password);
                    model.Password = pass;

                    var kq = dao.Insert(model);
                    if (!string.IsNullOrEmpty(kq))
                    {
                        SetAlert("Tạo mới người dùng thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Tạo mới người dùng không thành công", "error");
                        return RedirectToAction("Create", "User");
                    }
                }

            }
            catch (Exception e1){}
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string ma)
        {
            var user = new UserDao().Find(ma);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserAccount model)
        {
           
            
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Password))
                    {
                        SetAlert("Không được để mật khẩu trống", "warning");
                        return View();
                    }
                    var dao = new UserDao();
                    var pass = Encryptor.EncryptMD5(model.Password);
                    model.Password = pass;

                    var kq = dao.Update(model);
                    if (kq)
                    {
                        SetAlert("Cập Nhật người dùng thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Cập Nhật người dùng không thành công", "error");
                        return RedirectToAction("Update", "User");
                    }
                }

           
            return View();
        }

        
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index", "User");

        }
    }
}