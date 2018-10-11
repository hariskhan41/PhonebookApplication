using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class CreatePersonController : Controller
    {
        

        // GET: CreatePerson
        public ActionResult Index()
        {
            return View();
        }


        // GET: CreatePerson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreatePerson/Create
        [Authorize]
        public ActionResult Create()
        {
            string user = User.Identity.Name;
            return View();
        }

        // POST: CreatePerson/Create
        [HttpPost]
        public ActionResult Create(CreatePersonModel obj)
        {
            Person p = new Person();
            p.FirstName = obj.FirstName;
            p.MiddleName = obj.MiddleName;
            p.LastName = obj.LastName;
            p.DateOfBirth = obj.DateOfBirth;
            p.HomeAddress = obj.HomeAddress;
            p.HomeCity = obj.HomeCity;
            p.FaceBookAccountId = obj.FacebookAccountId;
            p.LinkedInId = obj.LinkedInId;
            p.TwitterId = obj.TwitterId;
            p.AddedBy = User.Identity.GetUserId();
            p.EmailId = obj.EmailId;
            p.AddedOn = DateTime.Now;
            p.UpdateOn = DateTime.Now;
            PhoneBookDbEntities2 db = new PhoneBookDbEntities2();
            
            //using (PhoneBookDbEntities2 db = new PhoneBookDbEntities2())
            //{
            //    db.People.Add(p);
            //    db.SaveChanges();
            //}

            string id = "";
            List<AspNetUser> dbUserList = db.AspNetUsers.ToList();

            foreach (AspNetUser usr in dbUserList)
            {
                if (usr.Email == User.Identity.Name)
                {
                    id = usr.Id;
                }
            }


            var lstCPM = new List<CreatePersonModel>();
            foreach (Person p1 in db.People)
            {
                if (p1.AddedBy == id)
                {
                    CreatePersonModel CPM = new CreatePersonModel();
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
                    
                    lstCPM.Add(CPM);
                }
            }

            db.People.Add(p);
            db.SaveChanges();

            

            return RedirectToAction("Create", "ViewPerson");
            //
            /*catch
            {
                return View();
            }*/
        }

        // GET: CreatePerson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreatePerson/Edit/5
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

        // GET: CreatePerson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreatePerson/Delete/5
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
