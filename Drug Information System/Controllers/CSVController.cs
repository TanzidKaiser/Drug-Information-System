using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Drug_Information_System.Context;
using Microsoft.Ajax.Utilities;
using System.IO;
using Drug_Information_System.Models;

namespace Drug_Information_System.Controllers
{
    public class CSVController : Controller
    {

        //DrugInformationContext db = new DrugInformationContext();

        //public ActionResult Index()
        //{
        //    //Create();
        //    //Delete();

        //    var data = db.UserActivities.Where(c => c.UserId != null && c.BrandId != null).GroupBy(d => d.BrandId).Select(e => e.FirstOrDefault()).ToList();
        //    var person = db.UserActivities.Where(b => b.UserId != null).GroupBy(c => c.UserId).Select(d => d.FirstOrDefault()).ToList();
        //    var data1 =
        //        db.UserActivities.Where(c => c.UserId != null && c.BrandId != null)
        //            .GroupBy(d => new { d.BrandId, d.UserId })
        //            .Select(e => new { e.Key.BrandId, e.Key.UserId })
        //            .ToList();


        //    #region Generate arff file

        //    var arffPath = Path.Combine(Server.MapPath("~/Domain"), "activityARFF.arff");



        //    //if (arffPath != null || arffPath != string.Empty)
        //    //{
        //    //    if (System.IO.File.Exists(arffPath))
        //    //    {
        //    //        System.IO.File.Delete(arffPath);
        //    //    }
        //    //}







        //    //StringBuilder arffContent = new StringBuilder();

        //    //arffContent.AppendLine("@relation drug");
        //    //foreach (var values in data)
        //    //{
        //    //    arffContent.AppendLine("@attribute " + values.BrandId + " {0,1}");
        //    //}
        //    //arffContent.AppendLine("@data");

        //    //foreach (var values in person)
        //    //{
        //    //    int? personId = values.UserId;
        //    //    string drugid = "";
        //    //    foreach (var value in data)
        //    //    {
        //    //        int flag = 0;
        //    //        foreach (var item in data1)
        //    //        {
        //    //            if (item.UserId == personId && item.BrandId == value.BrandId)
        //    //            {
        //    //                flag = 1;
        //    //                break;
        //    //            }
        //    //        }

        //    //        if (flag != 0)
        //    //        {
        //    //            drugid = drugid + ",1";
        //    //        }
        //    //        else
        //    //        {
        //    //            drugid = drugid + ",0";
        //    //        }
        //    //    }
        //    //    arffContent.AppendLine(drugid.TrimStart(new char[] { ',' }));
        //    //}

        //    //System.IO.File.AppendAllText(arffPath, arffContent.ToString());






        //    #endregion





        //    #region generate CSV File

        //    //StringBuilder csvContent = new StringBuilder();
        //    //string drugId = "";
        //    //foreach (var values in data)
        //    //{
        //    //    drugId = drugId + "," + values.BrandId;
        //    //}
        //    //csvContent.AppendLine(drugId.TrimStart(new char[] { ',' }));


        //    //foreach (var values in person)
        //    //{
        //    //    int? personId = values.UserId;
        //    //    string drugid = "";
        //    //    foreach (var value in data)
        //    //    {
        //    //        int flag = 0;
        //    //        foreach (var item in data1)
        //    //        {
        //    //            if (item.UserId == personId && item.BrandId == value.BrandId)
        //    //            {
        //    //                flag = 1;
        //    //                break;
        //    //            }
        //    //        }

        //    //        if (flag != 0)
        //    //        {
        //    //            drugid = drugid + ",1";
        //    //        }
        //    //        else
        //    //        {
        //    //            drugid = drugid + ",0";
        //    //        }
        //    //    }
        //    //    csvContent.AppendLine(drugid.TrimStart(new char[] { ',' }));
        //    //}


        //    //var csvPath = Path.Combine(Server.MapPath("~/Domain"), "activityCSV.csv");
        //    //if (csvPath != null || csvPath != string.Empty)
        //    //{
        //    //    if (System.IO.File.Exists(csvPath))
        //    //    {
        //    //        System.IO.File.Delete(csvPath);
        //    //    }
        //    //}


        //    //System.IO.File.AppendAllText(csvPath, csvContent.ToString());

        //    #endregion



        //    return View();
        //}

        ////public string Create()
        ////{
        ////    var data = db.UserActivities.Where(c => c.UserId != null && c.BrandId != null).GroupBy(d => d.BrandId).Select(e => e.FirstOrDefault()).ToList();
        ////    var person = db.UserActivities.Where(b => b.UserId != null).GroupBy(c => c.UserId).Select(d => d.FirstOrDefault()).ToList();
        ////    var data1 =
        ////        db.UserActivities.Where(c => c.UserId != null && c.BrandId != null)
        ////            .GroupBy(d => new { d.BrandId, d.UserId })
        ////            .Select(e => new { e.Key.BrandId, e.Key.UserId })
        ////            .ToList();

        ////    StringBuilder arffContent = new StringBuilder();

        ////    arffContent.AppendLine("@relation drug");
        ////    foreach (var values in data)
        ////    {
        ////        arffContent.AppendLine("@attribute " + values.BrandId + " {0,1}");
        ////    }
        ////    arffContent.AppendLine("@data");

        ////    foreach (var values in person)
        ////    {
        ////        int? personId = values.UserId;
        ////        string drugid = "";
        ////        foreach (var value in data)
        ////        {
        ////            int flag = 0;
        ////            foreach (var item in data1)
        ////            {
        ////                if (item.UserId == personId && item.BrandId == value.BrandId)
        ////                {
        ////                    flag = 1;
        ////                    break;
        ////                }
        ////            }

        ////            if (flag != 0)
        ////            {
        ////                drugid = drugid + ",1";
        ////            }
        ////            else
        ////            {
        ////                drugid = drugid + ",0";
        ////            }
        ////        }
        ////        arffContent.AppendLine(drugid.TrimStart(new char[] { ',' }));
        ////    }
        ////    var arffPath = Path.Combine(Server.MapPath("~/Domain"), "activityARFF.arff");
        ////    System.IO.File.AppendAllText(arffPath, arffContent.ToString());
        ////    return "Create Successfull";
        ////}

        ////public string Delete()
        ////{
        ////    var arffPath = Path.Combine(Server.MapPath("~/Domain"), "activityARFF.arff");

        ////    if (arffPath != null || arffPath != string.Empty)
        ////    {
        ////        if (System.IO.File.Exists(arffPath))
        ////        {
        ////            System.IO.File.Delete(arffPath);
        ////        }
        ////    }
        ////    return "Delete Successfull";
        ////}

       
    }
}