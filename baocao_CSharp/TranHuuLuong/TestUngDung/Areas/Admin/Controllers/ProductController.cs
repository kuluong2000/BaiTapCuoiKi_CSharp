using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        //public ActionResult Index()
        //{
        //    var dao = new ProductDao();
        //    return View(dao.ListAll());
        //}
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var result = new ProductDao();

            var model = result.ListAll();

            return View(model.ToPagedList(page, pagesize));
        }
      
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var result = new ProductDao();
            var model = result.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "Name", selectedId);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.ID.ToString()))
                    {
                        SetAlert("Mã sản phẩm không được để  trống", "warning");
                        return View();
                    }
                    var dao = new ProductDao();

                    if (dao.Find(model.ID) != null)
                    {
                        SetAlert("Mã  sản phẩm đã tồn tại", "warning");
                        return RedirectToAction("Create", "Product");
                    }

                    string result = dao.Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Tạo mới sản phẩm thành công!", "success");
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        SetAlert("Tạo mới sản phẩm không thành công!", "error");
                    }
                }
                return View("Index");
            }
            catch(Exception) {
                return null;
            }
        }
        //detail
        public ActionResult Detail(int id)
        {

            var detail = new ProductDao().Find(id);
            return View(detail);
        }
        [HttpGet]
 
        public ActionResult Edit(int ma)
        {
            SetViewBag();
            var user = new ProductDao().Find(ma);
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                if (string.IsNullOrEmpty(product.Name) && string.IsNullOrEmpty(product.UnitCost.ToString()) && string.IsNullOrEmpty(product.Quantity.ToString()) && string.IsNullOrEmpty(product.CategoryID.ToString()))
                {
                    SetAlert("Thông tin không được cập nhật trống", "error");
                    return RedirectToAction("Edit", "Product");
                }
                var kq = dao.Update(product);
                if (kq == true)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Cập nhật sản phẩm không thành công", "error");
                    return RedirectToAction("Edit", "Product");
                }
            }
         
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
      
    }
}