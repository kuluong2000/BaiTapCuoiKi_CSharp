using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //tạo class Encryptor trong thư mục common để chứa hàm mã hóa mật khẩu
                //tạo class Constants trong thư mục common để lưu trữ Session Login
                var kq = dao.login(login.UserName, Encryptor.EncryptMD5(login.Password),login.Status);
                if (kq == 1)
                {
                    //ModelState.AddModelError("","Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}