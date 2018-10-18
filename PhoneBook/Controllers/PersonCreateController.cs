using Microsoft.AspNet.Identity;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class PersonCreateController : Controller
    {
        // GET: PersonCreate
        public ActionResult Index()
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();

            List<PersonViewModel> lstPVM = new List<PersonViewModel>();
            foreach (Person p in db.People)
            {
                if (p.AddedBy == User.Identity.GetUserId())
                {
                    PersonViewModel PVM = new PersonViewModel();
                    PVM.FirstName = p.FirstName;
                    PVM.MiddleName = p.MiddleName;
                    PVM.LastName = p.LastName;
                    PVM.HomeAddress = p.HomeAddress;
                    PVM.HomeCity = p.HomeCity;
                    PVM.FaceBookAccountId = p.FaceBookAccountId;
                    PVM.LinkedInId = p.LinkedInId;
                    PVM.TwitterId = p.TwitterId;
                    PVM.ImagePath = p.ImagePath;
                    PVM.EmailId = p.EmailId;
                    PVM.DateOfBirth = p.DateOfBirth;
                    PVM.AddedBy = User.Identity.Name;
                    PVM.UpdateOn = p.UpdateOn;
                    PVM.AddedOn = p.AddedOn;
                    PVM.PersonId = p.PersonId;
                    lstPVM.Add(PVM);
                }
            }
            return View(lstPVM);
        }

        // GET: PersonCreate/Details/5
        public ActionResult Details(int id)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();

            List<DetailsViewModel> lstDVM = new List<DetailsViewModel>();
            foreach (Contact c in db.Contacts)
            {
                if (c.PersonId == id)
                {
                    DetailsViewModel DVM = new DetailsViewModel();
                    DVM.ContactNo = c.ContactNumber;
                    DVM.Type = c.Type;
                    DVM.PersonId = c.PersonId;
                    DVM.ContactId = c.ContactId;
                    lstDVM.Add(DVM);
                }
            }
            return View(lstDVM);
        }

        // GET: PersonCreate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonCreate/Create
        [HttpPost]
        public ActionResult Create(PersonCreateViewModel obj)
        {
            Person p = new Person();
            p.FirstName = obj.FirstName;
            p.MiddleName = obj.MiddleName;
            p.LastName = obj.LastName;
            p.DateOfBirth = obj.DateOfBirth;
            p.HomeAddress = obj.HomeAddress;
            p.HomeCity = obj.HomeCity;
            p.FaceBookAccountId = obj.FaceBookAccountId;
            p.LinkedInId = obj.LinkedInId;
            p.ImagePath = obj.ImagePath;
            p.TwitterId = obj.TwitterId;
            p.EmailId = obj.EmailId;
            
            p.AddedOn = DateTime.Now;
            p.UpdateOn = DateTime.Now;

            PhonebookDb1Entities db = new PhonebookDb1Entities();

            string id = User.Identity.GetUserId();
            p.AddedBy = id;
            db.People.Add(p);
            db.SaveChanges();
            
            /*List<AspNetUser> lstAsp = db.AspNetUsers.ToList();
            foreach (AspNetUser u in lstAsp)
            {

            }*/

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

        // GET: PersonCreate/Edit/5
        public ActionResult Edit(int id)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();

            EditPersonViewModel EPVM = new EditPersonViewModel();

            foreach (Person p in db.People)
            {
                if (p.PersonId == id)
                {
                    EPVM.FirstName = p.FirstName;
                    EPVM.MiddleName = p.MiddleName;
                    EPVM.LastName = p.LastName;
                    EPVM.DateOfBirth = p.DateOfBirth;
                    EPVM.HomeAddress = p.HomeAddress;
                    EPVM.HomeCity = p.HomeCity;
                    EPVM.ImagePath = p.ImagePath;
                    EPVM.FaceBookAccountId = p.FaceBookAccountId;
                    EPVM.TwitterId = p.TwitterId;
                    EPVM.LinkedInId = p.LinkedInId;
                    EPVM.EmailId = p.EmailId;
                    break;
                }
            }
            return View(EPVM);
        }

        // POST: PersonCreate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditPersonViewModel obj)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();

            db.People.Find(id).FirstName = obj.FirstName;
            db.People.Find(id).MiddleName = obj.MiddleName;
            db.People.Find(id).LastName = obj.LastName;
            db.People.Find(id).DateOfBirth = obj.DateOfBirth;
            db.People.Find(id).HomeAddress = obj.HomeAddress;
            db.People.Find(id).HomeCity = obj.HomeCity;
            db.People.Find(id).ImagePath = obj.ImagePath;
            db.People.Find(id).FaceBookAccountId = obj.FaceBookAccountId;
            db.People.Find(id).TwitterId = obj.TwitterId;
            db.People.Find(id).LinkedInId = obj.LinkedInId;
            db.People.Find(id).EmailId = obj.EmailId;

            db.SaveChanges();

            return RedirectToAction("Index", "PersonCreate");
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

        // GET: PersonCreate/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PhonebookDb1Entities db = new PhonebookDb1Entities();

                foreach (Contact c in db.Contacts)
                {
                    if (c.PersonId == id)
                    {
                        db.Contacts.Remove(c);
                    }
                }

                foreach (Person p in db.People)
                {
                    if (p.PersonId == id)
                    {
                        db.People.Remove(p);
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index", "PersonCreate");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "PersonCreate");
            }
        }

        // POST: PersonCreate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            PhonebookDb1Entities db = new PhonebookDb1Entities();
            foreach (Person p in db.People)
            {
                if (p.PersonId == id)
                {
                    db.People.Remove(p);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "PersonCreate");
            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
