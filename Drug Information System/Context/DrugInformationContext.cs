using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Drug_Information_System.Models;

namespace Drug_Information_System.Context
{
    public class DrugInformationContext : DbContext
    {

        public DrugInformationContext()
        {
            Configuration.ProxyCreationEnabled = false;
            
        }
        public DbSet<DrugBrandInfo> DrugBrandInfos { get; set; }
        public DbSet<DrugSystemicClass> DrugSystemicClasses { get; set; }
        public DbSet<DrugTherapiticClass> DrugTherapiticClasses { get; set; }
        public DbSet<DrugGeneric> DrugGenerics { get; set; }
        public DbSet<DrugStatus> DrugStatuses { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public DbSet<PharmaCompany> PharmaCompanies { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialUser> SocialUsers { get; set; }
        public DbSet<DrugsRating> DrugsRatings { get; set; }
        public DbSet<PregnancyCategory> PregnancyCategories { get; set; }
        public DbSet<IndicationGenericRelation> IndicationGenericRelations { get; set; }
        public DbSet<TherapiticGenericRelation> TherapiticGenericRelations { get; set; }
        public DbSet<PharmaInformation> PharmaInformations { get; set; }
        public DbSet<HospitalsAndClinics> HospitalsAndClinicses { get; set; }

        public DbSet<DoctorPrescription> DoctorPrescriptions { get; set; }

        public DbSet<PrescribedDrugs> PrescribedDrugses { get; set; }

        public DbSet<MessageInfo> MessageInfos { get; set; }

    }
}