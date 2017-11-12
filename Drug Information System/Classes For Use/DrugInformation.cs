using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Drug_Information_System.Context;
using Drug_Information_System.Models;

namespace Drug_Information_System.Class
{
    public class DrugInformation
    {
        private DrugInformationContext db = new DrugInformationContext();

        

        public double? UserRating(int? id)
        {
            var userRating = db.DrugsRatings.Where(c => c.BrandId == id).Average(c => c.UserRatting);
            return userRating;
        }

        public double? ProfessionalRating(int? id)
        {
            var professionalRating = db.DrugsRatings.Where(c => c.BrandId == id).Average(c => c.ProfessionalRatting);
            return professionalRating;
        }


        public string SetPersonalRating(string drugRating, int drugId, User user, SocialUser socialUser)
        {
            string message = "";
            if (user != null)
            {
                string rating = drugRating;
                int userId = user.Id;
                int brandId = drugId;

                if (user.OccupationsId == 1)
                {
                    var rate = db.DrugsRatings.SingleOrDefault(c => c.UserId == userId && c.BrandId == brandId);
                    if (rate != null)
                    {
                        rate.ProfessionalRatting = Convert.ToInt32(rating);
                        db.Entry(rate).State = EntityState.Modified;
                        var rowAffected = db.SaveChanges();

                        if (rowAffected > 0)
                        {
                            message = "Save Successfull";
                        }
                    }
                    else
                    {
                        DrugsRating drugsRating = new DrugsRating()
                        {
                            UserId = userId,
                            BrandId = brandId,
                            ProfessionalRatting = Convert.ToInt32(rating)
                        };
                        db.DrugsRatings.Add(drugsRating);
                        var rowAffected = db.SaveChanges();

                        if (rowAffected > 0)
                        {
                            message = "Save Successfull";
                        }
                    }
                }
                else if (user.OccupationsId == 2)
                {
                    var rate = db.DrugsRatings.SingleOrDefault(c => c.UserId == userId && c.BrandId == brandId);
                    if (rate != null)
                    {
                        rate.UserRatting = Convert.ToInt32(rating);
                        db.Entry(rate).State = EntityState.Modified;
                        var rowAffected = db.SaveChanges();

                        if (rowAffected > 0)
                        {
                            message = "Save Successfull";
                        }
                    }
                    else
                    {
                        DrugsRating drugsRating = new DrugsRating()
                        {
                            UserId = userId,
                            BrandId = brandId,
                            UserRatting = Convert.ToInt32(rating)
                        };
                        db.DrugsRatings.Add(drugsRating);
                        var rowAffected = db.SaveChanges();

                        if (rowAffected > 0)
                        {
                            message = "Save Successfull";
                        }
                    }
                }
            }
            else if (socialUser != null)
            {
                string rating = drugRating;
                int socialUserId = socialUser.Id;
                int brandId = drugId;

                var rate = db.DrugsRatings.SingleOrDefault(c => c.SocialUserId == socialUserId && c.BrandId == brandId);
                if (rate != null)
                {
                    rate.UserRatting = Convert.ToInt32(rating);
                    db.Entry(rate).State = EntityState.Modified;
                    var rowAffected = db.SaveChanges();

                    if (rowAffected > 0)
                    {
                        message = "Save Successfull";
                    }
                }
                else
                {
                    DrugsRating drugsRating = new DrugsRating()
                    {
                        SocialUserId = socialUserId,
                        BrandId = brandId,
                        UserRatting = Convert.ToInt32(rating)
                    };
                    db.DrugsRatings.Add(drugsRating);
                    var rowAffected = db.SaveChanges();

                    if (rowAffected > 0)
                    {
                        message = "Save Successfull";
                    }
                }
            }
            return message;
        }
    }
}