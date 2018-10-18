using Microsoft.AspNet.Identity;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class AddContactsController : Controller
    {
        // GET: AddContacts
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddContacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddContacts/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: AddContacts/Create
        [HttpPost]
        public ActionResult Create(int id, AddContactsViewModel obj)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();
            
            
            Contact c = new Contact();
            c.ContactNumber = obj.ContactNo;
            c.Type = obj.Type;
            c.PersonId = id;

            db.Contacts.Add(c);
            db.SaveChanges();

            
            return RedirectToAction("Index", "PersonCreate");
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: AddContacts/Edit/5
        public ActionResult Edit(int id)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();

            EditContactsViewModel ECVM = new EditContactsViewModel();
            foreach (Contact c in db.Contacts)
            {
                if (c.PersonId == id)
                {
                    ECVM.ContactNo = c.ContactNumber;
                    ECVM.Type = c.Type;
                }
            }
            return View(ECVM);
        }

        // POST: AddContacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditContactsViewModel obj)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();
            db.Contacts.Find(id).ContactNumber = obj.ContactNo;
            db.Contacts.Find(id).Type = obj.Type;

            db.SaveChanges();

            return RedirectToAction("Details", "PersonCreate", new { id = db.Contacts.Find(id).PersonId });
            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: AddContacts/Delete/5
        public ActionResult Delete(int id)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();

            foreach (Contact c in db.Contacts)
            {
                if (c.ContactId == id)
                {
                    db.Contacts.Remove(c);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Details", "PersonCreate", new { id = id });
        }

        // POST: AddContacts/Delete/5
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
