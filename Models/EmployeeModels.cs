using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;   
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmployeeApplication1.Models
{

    /// <summary>
    /// Employee class - modle based on Northwind Exmployees table
    /// </summary>
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last Name maximum length is 20")]
        public string LastName { get; set; }

        [StringLength(20, ErrorMessage = "First Name maximum length is 10")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "Title maximum length is 30")]
        public string Title { get; set; }

        [StringLength(25, ErrorMessage = "Maximum length is 25")]
        public string TitleOfCourtesy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(60, ErrorMessage = "Maximum length is 60")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "Maximum length is 15")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "Maximum length is 15")]
        public string Region { get; set; }

        [StringLength(10, ErrorMessage = "Maximum length is 10")]
        public string PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "Maximum length is 15")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "Maximum length is 24")]
        public string HomePhone { get; set; }

        [StringLength(4, ErrorMessage = "Maximum length is 4")]
        public string Extension { get; set; }

        public byte[] Photo { get; set; }

        //ntext data type
        public string Notes { get; set; }

        public int ReportsTo { get; set; }

        //list of valid managers for ReportsTo
        public IEnumerable<SelectListItem> Managers { get; set; }

        [StringLength(255, ErrorMessage = "Maximum length is 255")]
        public string PhotoPath { get; set; }


    }

    // class to represent managers for populatimg drop down list.
    public class Manager
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }



}