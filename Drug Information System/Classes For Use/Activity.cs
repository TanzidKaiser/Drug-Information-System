using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Drug_Information_System.Context;
using Drug_Information_System.Models;

namespace Drug_Information_System.Controllers
{
    public class Activity
    {
        private DrugInformationContext db = new DrugInformationContext();

        dynamic session = HttpContext.Current.Session["user"];
        dynamic userType = HttpContext.Current.Session["userType"];

        public void ClickActivityForBrand(int? id)
        {

            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Click",
                    ActivityTime = DateTime.Today
                };

                var drugBrand = db.DrugBrandInfos.Find(id);
                if (drugBrand != null)
                {
                    userActivity.BrandId = drugBrand.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };
                    var drugBrand = db.DrugBrandInfos.Find(id);
                    if (drugBrand != null)
                    {
                        userActivity.BrandId = drugBrand.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };
                    var drugBrand = db.DrugBrandInfos.Find(id);
                    if (drugBrand != null)
                    {
                        userActivity.BrandId = drugBrand.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void ClickActivityForClass(int? classId)
        {


            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Click",
                    ActivityTime = DateTime.Today
                };

                var drugClasses = db.DrugTherapiticClasses.Find(classId);
                if (drugClasses != null)
                {
                    userActivity.TherapiticClassId = drugClasses.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var drugClasses = db.DrugTherapiticClasses.Find(classId);
                    if (drugClasses != null)
                    {
                        userActivity.TherapiticClassId = drugClasses.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var drugClasses = db.DrugTherapiticClasses.Find(classId);
                    if (drugClasses != null)
                    {
                        userActivity.TherapiticClassId = drugClasses.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }


            }
        }

        public void ClickActivityForPharma(int? pharmaId)
        {


            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Click",
                    ActivityTime = DateTime.Today
                };

                var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);
                if (pharmaCompanies != null)
                {
                    userActivity.PharmaId = pharmaCompanies.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);
                    if (pharmaCompanies != null)
                    {
                        userActivity.PharmaId = pharmaCompanies.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);
                    if (pharmaCompanies != null)
                    {
                        userActivity.PharmaId = pharmaCompanies.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void ClickActivityForGeneric(int? genericId)
        {

            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Click",
                    ActivityTime = DateTime.Today
                };

                var drugGenerics = db.DrugGenerics.Find(genericId);
                if (drugGenerics != null)
                {
                    userActivity.GenericId = drugGenerics.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var drugGenerics = db.DrugGenerics.Find(genericId);
                    if (drugGenerics != null)
                    {
                        userActivity.GenericId = drugGenerics.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var drugGenerics = db.DrugGenerics.Find(genericId);
                    if (drugGenerics != null)
                    {
                        userActivity.GenericId = drugGenerics.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void ClickActivityForIndication(int? indicationId)
        {


            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Click",
                    ActivityTime = DateTime.Today
                };

                var indications = db.Indications.Find(indicationId);
                if (indications != null)
                {
                    userActivity.IndicationId = indications.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var indications = db.Indications.Find(indicationId);
                    if (indications != null)
                    {
                        userActivity.IndicationId = indications.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Click",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var indications = db.Indications.Find(indicationId);
                    if (indications != null)
                    {
                        userActivity.IndicationId = indications.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }




        public void SearchActivityForBrand(int? id)
        {

            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Search",
                    ActivityTime = DateTime.Today
                };

                var drugBrand = db.DrugBrandInfos.Find(id);
                if (drugBrand != null)
                {
                    userActivity.BrandId = drugBrand.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };
                    var drugBrand = db.DrugBrandInfos.Find(id);
                    if (drugBrand != null)
                    {
                        userActivity.BrandId = drugBrand.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };
                    var drugBrand = db.DrugBrandInfos.Find(id);
                    if (drugBrand != null)
                    {
                        userActivity.BrandId = drugBrand.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void SearchActivityForClass(int? classId)
        {


            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Search",
                    ActivityTime = DateTime.Today
                };

                var drugClasses = db.DrugTherapiticClasses.Find(classId);
                if (drugClasses != null)
                {
                    userActivity.TherapiticClassId = drugClasses.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var drugClasses = db.DrugTherapiticClasses.Find(classId);
                    if (drugClasses != null)
                    {
                        userActivity.TherapiticClassId = drugClasses.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var drugClasses = db.DrugTherapiticClasses.Find(classId);
                    if (drugClasses != null)
                    {
                        userActivity.TherapiticClassId = drugClasses.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }


            }
        }

        public void SearchActivityForPharma(int? pharmaId)
        {


            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Search",
                    ActivityTime = DateTime.Today
                };

                var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);
                if (pharmaCompanies != null)
                {
                    userActivity.PharmaId = pharmaCompanies.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);
                    if (pharmaCompanies != null)
                    {
                        userActivity.PharmaId = pharmaCompanies.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);
                    if (pharmaCompanies != null)
                    {
                        userActivity.PharmaId = pharmaCompanies.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void SearchActivityForGeneric(int? genericId)
        {

            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Search",
                    ActivityTime = DateTime.Today
                };

                var drugGenerics = db.DrugGenerics.Find(genericId);
                if (drugGenerics != null)
                {
                    userActivity.GenericId = drugGenerics.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var drugGenerics = db.DrugGenerics.Find(genericId);
                    if (drugGenerics != null)
                    {
                        userActivity.GenericId = drugGenerics.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var drugGenerics = db.DrugGenerics.Find(genericId);
                    if (drugGenerics != null)
                    {
                        userActivity.GenericId = drugGenerics.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void SearchActivityForIndication(int? indicationId)
        {


            if (session == null)
            {
                UserActivity userActivity = new UserActivity()
                {
                    ActivityType = "Search",
                    ActivityTime = DateTime.Today
                };

                var indications = db.Indications.Find(indicationId);
                if (indications != null)
                {
                    userActivity.IndicationId = indications.Id;
                    db.UserActivities.Add(userActivity);
                    db.SaveChanges();
                }
            }
            else
            {
                if (userType == "localUser")
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        UserId = session.Id
                    };

                    var indications = db.Indications.Find(indicationId);
                    if (indications != null)
                    {
                        userActivity.IndicationId = indications.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    UserActivity userActivity = new UserActivity()
                    {
                        ActivityType = "Search",
                        ActivityTime = DateTime.Today,
                        SocialUserId = session.Id
                    };

                    var indications = db.Indications.Find(indicationId);
                    if (indications != null)
                    {
                        userActivity.IndicationId = indications.Id;
                        db.UserActivities.Add(userActivity);
                        db.SaveChanges();
                    }
                }
            }
        }




    }
}