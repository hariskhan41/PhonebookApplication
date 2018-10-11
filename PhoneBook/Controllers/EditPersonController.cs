using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class EditPersonController : Controller
    {
        // GET: EditPerson
        public ActionResult Index()
        {
            return View();
        }

        // GET: EditPerson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditPerson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            return View();
            /*try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }*/
        }

        // GET: EditPerson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EditPerson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EditPerson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditPerson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
