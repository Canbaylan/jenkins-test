using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jenk_test.Models;
using System.Data.Entity;


namespace jenk_test.Controllers
{
    
    public class CompanyController : Controller
    {
        private readonly companyEntities dbContext; 
        public CompanyController()
        {
            dbContext = new companyEntities(); 
        }
        public ActionResult Index()
        {
            var companies = dbContext.companyInfo.ToList();
            return View(companies);
        }

       
        public ActionResult Details(int id)
        {
            var company = dbContext.companyInfo.Find(id);
            return View(company);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(companyInfo company)
        {
            if (ModelState.IsValid)
            {
                dbContext.companyInfo.Add(company);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

     
        public ActionResult Edit(int id)
        {
            var company = dbContext.companyInfo.Find(id);
            return View(company);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(companyInfo company)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(company).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

   
        public ActionResult Delete(int id)
        {
            var company = dbContext.companyInfo.Find(id);
            return View(company);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = dbContext.companyInfo.Find(id);
            dbContext.companyInfo.Remove(company);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}