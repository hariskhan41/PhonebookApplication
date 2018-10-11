using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class ViewPersonController : Controller
    {
        // GET: ViewPerson
        public ActionResult Index()
        {
            return View();
        }

        // GET: ViewPerson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewPerson/Create
        public ActionResult Create()
        {
            PhoneBookDbEntities2 db = new PhoneBookDbEntities2();

            string id = "";
            List<AspNetUser> dbUserList = db.AspNetUsers.ToList();

            foreach (AspNetUser usr in dbUserList)
            {
                if (usr.Email == User.Identity.Name)
                {
                    id = usr.Id;
                }
            }
            

            var lstCPM = new List<ViewPersonModel>();
            foreach (Person p1 in db.People)
            {
                if (p1.AddedBy == id)
                {
                    ViewPersonModel CPM = new ViewPersonModel();
                    CPM.FirstName = p1.FirstName;
                    CPM.MiddleName = p1.MiddleName;
                    CPM.LastName = p1.LastName;
                    CPM.HomeAddress = p1.HomeAddress;
                    CPM.HomeCity = p1.HomeCity;
                    CPM.FacebookAccountId = p1.FaceBookAccountId;
                    CPM.LinkedInId = p1.LinkedInId;
                    CPM.TwitterId = p1.TwitterId;
                    CPM.EmailId = p1.EmailId;
                    CPM.ImagePath = p1.ImagePath;
                    CPM.AddedBy = User.Identity.Name;
                    CPM.AddedOn = p1.AddedOn;
                    CPM.UpdateOn = p1.UpdateOn;
                    CPM.PersonId = p1.PersonId;
                    lstCPM.Add(CPM);
                }
            }
            return View(lstCPM);
        }

        // POST: ViewPerson/Create
        [HttpPost]
        public ActionResult Create(ViewPersonModel obj)
        {
            PhoneBookDbEntities2 db = new PhoneBookDbEntities2();

            string id = "";
            List<AspNetUser> dbUserList = db.AspNetUsers.ToList();

            foreach (AspNetUser usr in dbUserList)
            {
                if (usr.Email == User.Identity.Name)
                {
                    id = usr.Id;
                }
            }


            var lstCPM = new List<ViewPersonModel>();
            foreach (Person p1 in db.People)
            {
                if (p1.AddedBy == id)
                {
                    ViewPersonModel CPM = new ViewPersonModel();
                    CPM.FirstName = p1.FirstName;
                    CPM.MiddleName = p1.MiddleName;
                    CPM.LastName = p1.LastName;
                    CPM.HomeAddress = p1.HomeAddress;
                    CPM.HomeCity = p1.HomeCity;
                    CPM.FacebookAccountId = p1.FaceBookAccountId;
                    CPM.LinkedInId = p1.LinkedInId;
                    CPM.TwitterId = p1.TwitterId;
                    CPM.EmailId = p1.EmailId;
                    CPM.ImagePath = p1.ImagePath;
                    CPM.AddedBy = User.Identity.Name;
                    CPM.AddedOn = p1.AddedOn;
                    CPM.UpdateOn = p1.UpdateOn;
                    CPM.PersonId = p1.PersonId;
                    lstCPM.Add(CPM);
                }
            }
            return View(lstCPM);
        }

        // GET: ViewPerson/Edit/5
        public ActionResult Edit(int id)
        {
            PhoneBookDbEntities2 db = new PhoneBookDbEntities2();
            EditPersonModel EPM = new EditPersonModel();
            foreach (Person p in db.People)
            {
                if (p.PersonId == id)
                {
                    EPM.FirstName = p.FirstName;
                    EPM.MiddleName = p.MiddleName;
                    EPM.LastName = p.LastName;
                    EPM.DateOfBirth = p.DateOfBirth;
                    EPM.HomeAddress = p.HomeAddress;
                    EPM.HomeCity = p.HomeCity;
                    EPM.FacebookAccountId = p.FaceBookAccountId;
                    EPM.LinkedInId = p.LinkedInId;
                    EPM.TwitterId = p.TwitterId;
                    EPM.EmailId = p.EmailId;
                    EPM.ImagePath = p.ImagePath;
                    break;
                }
            }
            return View(EPM);
        }

        // POST: ViewPerson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditPersonModel obj)
        {
            // TODO: Add update logic here
            PhoneBookDbEntities2 db = new PhoneBookDbEntities2();
            
            db.People.Find(id).FirstName = obj.FirstName;
            db.People.Find(id).MiddleName = obj.MiddleName;
            db.People.Find(id).LastName = obj.LastName;
            db.People.Find(id).DateOfBirth = obj.DateOfBirth;
            db.People.Find(id).HomeAddress = obj.HomeAddress;
            db.People.Find(id).HomeCity = obj.HomeCity;
            db.People.Find(id).ImagePath = obj.ImagePath;
            db.People.Find(id).LinkedInId = obj.LinkedInId;
            db.People.Find(id).FaceBookAccountId = obj.FacebookAccountId;
            db.People.Find(id).TwitterId = obj.TwitterId;
            db.People.Find(id).EmailId = obj.EmailId;
            db.SaveChanges();
            return RedirectToAction("Create", "ViewPerson");
        }

        // GET: ViewPerson/Delete/5
        public ActionResult Delete(int id)
        {
            PhoneBookDbEntities2 db = new PhoneBookDbEntities2();
            foreach (Person p in db.People)
            {
                if (p.PersonId == id)
                {
                    db.People.Remove(p);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Create", "ViewPerson");
            //return View();
        }

        // POST: ViewPerson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ViewPersonModel obj)
        {
            try
            {
                PhoneBookDbEntities2 db = new PhoneBookDbEntities2();
                foreach(Person p in db.People)
                {
                    if(p.PersonId == id)
                    {
                        db.People.Remove(p);
                    }
                }
                // TODO: Add delete logic here

                return RedirectToAction("Create", "ViewPerson");
            }
            catch
            {
                return View();
            }
        }
    }
}
