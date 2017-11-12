using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Drug_Information_System.Models;
using Drug_Information_System.Context;
using Facebook;
using Microsoft.Owin.Host.SystemWeb;
using Newtonsoft.Json;

namespace Drug_Information_System.Controllers
{
    public class AccountController : Controller
    {
        private DrugInformationContext db = new DrugInformationContext();


        public ActionResult Create()
        {
            var identity = Session["user"] as User;
            var socialUser = Session["user"] as SocialUser;

            if (identity == null && socialUser == null)
            {
                ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
                ViewBag.OccupationsId = new SelectList(db.Occupations, "Id", "Name");
                ViewBag.ProfessionId = new SelectList(db.Professions, "Id", "Name");

                ViewBag.message = "";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, HttpPostedFileBase file)
        {
            if (user.OccupationsId == 1 && user.ProfessionId == 3)
            {
                User users = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    UserApproval = false,
                    GenderId = user.GenderId,
                    OccupationsId = user.OccupationsId,
                    ProfessionId = user.ProfessionId,
                    UserRole = "user"
                };

                string message = UploadFile(user, file);
                if (message == "You have not specified a file.. !!!! Please try again ..")
                {
                    ViewBag.message = message;
                }
                else if (message == "Upload Failed")
                {
                    ViewBag.message = "Id Upload Failed !! Please try again ...";
                }
                else
                {
                    db.Users.Add(users);
                    var rowAffected = db.SaveChanges();
                    if (rowAffected > 0)
                    {
                        ViewBag.message = "Account Create Successfull";
                    }
                    else
                    {
                        ViewBag.message = "Account Create Failed";
                    }

                }
                
            }
            else
            {
                User users = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    UserApproval = true,
                    GenderId = user.GenderId,
                    OccupationsId = user.OccupationsId,
                    ProfessionId = user.ProfessionId,
                    UserRole = "user"
                };

                db.Users.Add(users);
                var rowAffected = db.SaveChanges();
                if (rowAffected > 0)
                {
                    ViewBag.message = "Account Create Successfull";
                }
                else
                {
                    ViewBag.message = "Account Create Failed";
                }
            }


            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", user.GenderId);
            ViewBag.OccupationsId = new SelectList(db.Occupations, "Id", "Name", user.OccupationsId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "Id", "Name", user.ProfessionId);

            //return RedirectToAction("Create");
            return View();
        }

        private string UploadFile(User user, HttpPostedFileBase file)
        {
            string message = " ";
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileType = Path.GetExtension(fileName);
                    fileName = user.UserName + fileType;
                    var path = Path.Combine(Server.MapPath("~/App_Data/DoctorIdentity"), fileName);
                    file.SaveAs(path);
                    message = "Upload Successfull";
                }
                catch (Exception ex)
                {
                    message = "Upload Failed";
                }
            }
            else
            {
                message = "You have not specified a file.. !!!! Please try again ..";
            }
            return message;
        }




        public ActionResult Login()
        {
            var identity = Session["user"] as User;
            var socialUser = Session["user"] as SocialUser;

            if (identity != null && identity.UserRole == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (identity == null && socialUser == null)
            {
                ViewBag.message = "";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var identity = db.Users.Any(c => (c.UserName.Equals(user.UserIdentity) && c.Password.Equals(user.Password) && c.UserApproval == true) || (c.Email.Equals(user.UserIdentity) && c.Password.Equals(user.Password) && c.UserApproval == true));
            var users = db.Users.Where(c => (c.UserName.Equals(user.UserIdentity) && c.Password.Equals(user.Password) && c.UserApproval == true) || (c.Email.Equals(user.UserIdentity) && c.Password.Equals(user.Password) && c.UserApproval == true));


            if (identity)
            {

                foreach (var value in users)
                {
                    Session["user"] = new User()
                    {
                        Id = value.Id,
                        UserName = value.UserName,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Address = value.Address,
                        Email = value.Email,
                        GenderId = value.GenderId,
                        OccupationsId = value.OccupationsId,
                        ProfessionId = value.ProfessionId,
                        UserRole = value.UserRole
                    };
                }
                Session["userType"] = "localUser";


                var session = Session["user"] as User;
                if (session.UserRole == "admin")
                {
                    Session["userRole"] = "admin";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Session["userRole"] = "user";
                    return RedirectToAction("Index", "Home");
                }

                
            }
            ViewBag.message = "userid and password is incorrect";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult IsUserNameAvailable(string userName)
        {
            return Json(!db.Users.Any(c => c.UserName == userName), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsEmailAvailable(string email)
        {
            return Json(!db.Users.Any(c => c.Email == email), JsonRequestBehavior.AllowGet);
        }


        #region Facebook Authentication
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "1743513262532791",
                client_secret = "a52e7a8814110c005ed94e3a0a94e32d",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "1743513262532791",
                client_secret = "a52e7a8814110c005ed94e3a0a94e32d",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            fb.AccessToken = accessToken;

            Session["AccessToken"] = accessToken;

            dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,email,gender,locale,timezone,currency,verified,picture,age_range,id");
            string email = me.email;
            string firstName = me.first_name;
            string lastName = me.middle_name + " " + me.last_name;
            string gender = me.gender;
            string picture = me.picture.data.url;

            var socialUser = db.SocialUsers.Any(c => c.Email == email);
            if (!socialUser)
            {
                SocialUser acc = new SocialUser()
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    Picture = picture,
                    SocialSiteName = "Facebook"
                };

                db.SocialUsers.Add(acc);
                db.SaveChanges();
            }

            var users = db.SocialUsers.Where(c => c.Email == email);
            foreach (var value in users)
            {
                Session["user"] = new SocialUser()
                {
                    Id = value.Id,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
            }
            Session["userType"] = "socialUser";

            FormsAuthentication.SetAuthCookie(email, false);
            return RedirectToAction("Index", "Home");
        }

        #endregion





        


    }
}
