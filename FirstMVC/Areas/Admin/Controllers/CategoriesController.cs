using FirstMVC.Data;
using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var categories = db.Categories.ToList();
                return View(categories);
            }
        }
        public ActionResult Create()
        {
            var categories = new Category();
            return View(categories);
        }

        [HttpPost]
        [ValidateInput(false)]//bu actiona html/script etiketleri artık gönderilebilir
        public ActionResult Create(Category categories)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Categories.Add(categories);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(categories);
        }
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var categories = db.Categories.Where(x => x.Id == id).FirstOrDefault();
                if (categories != null)
                {
                    return View(categories);
                }
                else
                {
                    return HttpNotFound();
                }

            }
        }

        [HttpPost]
        [ValidateInput(false)]//bu actiona html/script etiketleri artık gönderilebilir
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var oldCategory = db.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
                    if (oldCategory != null)
                    {
                        oldCategory.Name = category.Name;
                        oldCategory.Description = category.Description;                     
                        
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var category = db.Categories.Where(x => x.Id == id).FirstOrDefault();
                
                if (category != null)
                {
                    var projects = db.Projects.Where(x => x.CategoryId == id).ToList();
                    foreach (var item in projects)
                    {
                        item.CategoryId = null;
                    }
                    db.SaveChanges();
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
    }
}