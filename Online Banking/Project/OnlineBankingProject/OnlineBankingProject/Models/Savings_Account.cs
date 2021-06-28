using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBankingProject.Models
{
    public class Savings_Account
    {
        [Key]

        [Required(ErrorMessage = "* Please Enter Your First Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must not be more than 15, less than 3 char")]
        [DisplayName("First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Last Name")]
        [DisplayName("Last Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must not be more than 15, less than 3 char")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Father Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must not be more than 15, less than 3 char")]
        [DisplayName("Father Name")]
        public string Father_Name { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Mobile Number")]
        [DisplayName("Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public int Mobile_Number { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Email Id")]
        [DisplayName("Email Id")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email_Id { get; set; }

        [Required(ErrorMessage = "* Please Enter Your AadharCard Number")]

        [DisplayName("AadharCard Number")]
        public int AadharCard_Number { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        
        public DateTime Date_Of_Birth { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Residential Address line1")]
        [DisplayName("Residential Address line1")]
        public string Residential_Address_line1 { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Residential Address line2")]
        [DisplayName("Residential Address line2")]
        public string Residential_Address_line2 { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Residential Landmark")]
        [DisplayName("Residential Landmark")]
        public string Residential_Landmark { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Residential state")]
        [DisplayName("Residential State")]
        public string Residential_State { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Residential City")]
        [DisplayName("Residential City")]
        public string Residential_City { get; set; }



        [Required(ErrorMessage = "* Please Enter Your Residential Pincode")]
        [DisplayName("Residential Pincode")]
        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Please Enter Valid Postal Code.")]
        public int Residential_Pincode { get; set; }

        [Required(ErrorMessage = "* Please Enter Your  Permanent AddressLine1")]
        [DisplayName(" Permanent Address Line1")]
        public string Permanent_Address_Line1 { get; set; }


        [Required(ErrorMessage = "* Please Enter Your  Permanent Address Line2")]
        [DisplayName(" Permanent Address Line2")]
        public string Permanent_Address_Line2 { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Permanent Landmark")]
        [DisplayName("Permanent Landmark")]
        public string Permanent_Landmark { get; set; }

        [Required(ErrorMessage = "* Please Enter Your  Permanent State")]
        [DisplayName(" Permanent State")]
        public string Permanent_State { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Residential City")]
        [DisplayName(" Permanent City")]
        public string Permanent_City { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Permanent Pincode")]
        [DisplayName("Permanent Pincode")]
        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Please Enter Valid Postal Code.")]
        public int Permanent_Pincode { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Occupational type")]
        [DisplayName("Occupational type")]
        public string Occupational_type { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Source Of Income")]
        [DisplayName("Source Of Income")]
        public string Source_Of_Income { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Gross Annual Income")]
        [DisplayName("Gross Annual Income")]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter valid float Number")]
        public Double Gross_Annual_Income { get; set; }


        [Required(ErrorMessage = "* Please Enter Your Balance")]
        [DisplayName("Balance")]
        [Range(5000, Double.MaxValue, ErrorMessage = "* Please Enter Minimum Balance of 5000")]
        public Double Balance { get; set; }
    }
}