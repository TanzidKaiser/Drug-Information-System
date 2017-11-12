using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

using Drug_Information_System.Context;
using Drug_Information_System.Models;
using java.net;
using Microsoft.AspNet.Identity;
using sun.tools.java;
using weka.associations;
using weka.core;

namespace Drug_Information_System.Controllers
{
    public class DrugRecommendation
    {
        private DrugInformationContext db = new DrugInformationContext();


        public List<DrugBrandInfo> DrugBrandInfosForGeneric(int? drugId, int? genericId)
        {

            int minimum_rating = 0;
            
            var drugBrandInfos = db.DrugBrandInfos.Where(c => c.GenericId == genericId && c.Id != drugId);

            return drugBrandInfos.Take(4).ToList();

        }


        public List<DrugBrandInfo> AssociateDrugs(int? drugId, string dataPath)
        {
            
            List<DrugBrandInfo> drugList = new List<DrugBrandInfo>();

            


            weka.core.Instances data = new weka.core.Instances(new java.io.FileReader(dataPath));
            
            
            data.setClassIndex(data.numAttributes() - 1);
           
            Apriori apriori = new Apriori();

            apriori.setClassIndex(data.classIndex());
            apriori.buildAssociations(data);

            FastVector[] vector = apriori.getAllTheRules();

            for (int i = 0; i < vector[0].size(); i++)
            {
                string value1 = ((AprioriItemSet) vector[0].elementAt(i)).toString(data);
                string value2 = ((AprioriItemSet)vector[1].elementAt(i)).toString(data);

                string[] set1 = value1.Split(' ', '=');
                string[] set2 = value2.Split(' ', '=');

                if (set1[0].Equals(drugId.ToString()))
                {
                    if (set1[1] == "1" && set2[1] == "1")
                    {
                        int brandId = Convert.ToInt32(set2[0]);
                        var drug = db.DrugBrandInfos.SingleOrDefault(c => c.Id == brandId);
                        drugList.Add(drug);
                    }
                    break;
                }
            }
            return drugList;
        }

    }
}