using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Drug_Information_System.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Remote("IsUserNameAvailable", "Account", ErrorMessage = "username is already exists.")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Remote("IsEmailAvailable", "Account", ErrorMessage = "email is already exists.")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[DisplayName("Confirm Password")]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("Password")]

        //[NotMapped]
        //public string ConfirmPassword { get; set; }

        //[Required]
        [DisplayName("userId")]
        [NotMapped]
        public string UserIdentity { get; set; }

        [Required]
        public string UserRole { get; set; }

        [Required]
        public bool UserApproval { get; set; }


        [Required]
        public int? GenderId { get; set; }

        [Required]
        public int? OccupationsId { get; set; }

        [Required]
        public int? ProfessionId { get; set; }


        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("OccupationsId")]
        public virtual Occupation Occupation { get; set; }

        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }

        public virtual List<UserActivity> UserActivities { get; set; }
        public virtual List<DrugsRating> DrugsRatings { get; set; }
        public virtual List<DoctorPrescription> DoctorPrescriptions { get; set; }
    }


}