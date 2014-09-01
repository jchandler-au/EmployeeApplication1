using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using EmployeeApplication1.Models;
using System.Web.Configuration;
using Dapper;

namespace EmployeeApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            // SQL to select all employees - we would normally limit and or page slection but this is a small db
            string sqlCmd =
                "Select  EmployeeID ,LastName ,FirstName, Title ,TitleOfCourtesy " +
                ",BirthDate ,HireDate ,Address ,City ,Region ,PostalCode ,Country " +
                ",HomePhone ,Extension ,Photo ,Notes ,ReportsTo ,PhotoPath " +
                "  From Employees ";

            IEnumerable<Employee> result = null;

            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString))
            {
                result = conn.Query<Employee>(sqlCmd);
            }
            return View(result);
        }

        // Initial controller to test Dapper access.
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {


            string sqlCmd =
                "Select  EmployeeID ,LastName ,FirstName, Title ,TitleOfCourtesy " +
                ",BirthDate ,HireDate ,Address ,City ,Region ,PostalCode ,Country " +
                ",HomePhone ,Extension ,Photo ,Notes ,ReportsTo ,PhotoPath " +
                "  From Employees " +
                " where EmployeeId = @EmployeeId";


            Employee result = null;
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString))
            {
                result = conn.Query<Employee>(sqlCmd, new { EmployeeId = id }).FirstOrDefault();
            }
            return View(result);
        }

        // Not implemented - JC 01/09/2014
        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // Not implemented - JC 01/09/2014
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            string sqlCmd =
                 "Select  EmployeeID ,LastName ,FirstName, Title ,TitleOfCourtesy " +
                 ",BirthDate ,HireDate ,Address ,City ,Region ,PostalCode ,Country " +
                 ",HomePhone ,Extension, Photo ,Notes ,ReportsTo ,PhotoPath " +
                 "  From Employees " +
                 " where EmployeeId = @EmployeeId";

            // SQL to get valid reportsto ids - currently anyone but the chosen employee
            string sqlCmdMgrs =
                        "Select  EmployeeId , LastName, FirstName From Employees where EmployeeId <> @EmployeeId";


            Employee _employee = null;
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString))
            {
                // Get details for employee
                _employee = conn.Query<Employee>(sqlCmd, new { EmployeeId = id }).FirstOrDefault();

                // Get list of valid managers
                IEnumerable<Manager> _mgrs = conn.Query<Manager>(sqlCmdMgrs, new { EmployeeId = id });

                // Set valid managers drop down values
                _employee.Managers = new SelectList(_mgrs, "EmployeeId", "LastName", _employee.ReportsTo);
            }

            return View(_employee);
        }

        //private IEnumerable<SelectListItem> GetManagerList(IEnumerable<Manager> mgrs, int id)
        //{
        //    IEnumerable<SelectListItem> managerList = new IEnumerable<SelectListItem>()
        //    foreach(Manager m in mgrs)
        //    {
        //        SelectListItem i = new SelectListItem { Value = m.EmployeeId, Text = m.FirstName + " " + m.LastName };
        //        if (m.EmployeeId = id)
        //            i.Selected = true;
        //        managerList.Add(i);

        //    }
        //    return new SelectList()
        //}

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "EmployeeId,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Notes,ReportsTo,PhotoPath")] Employee e)
        {
            try
            {
                // TODO: Add update logic here

                string sqlCmd = "Update Employees " +
                         "Set  LastName = @lname ,FirstName = @fname, Title = @title ,TitleOfCourtesy = @titlec " +
                         " ,BirthDate = @bdate ,HireDate = @hdate ,Address = @address ,City = @city ,Region = @region " +
                         " ,PostalCode = @pcode ,Country = @country ,HomePhone = @hphone ,Extension = @ext" +
                         " ,Notes = @notes,ReportsTo = @reportsto,PhotoPath = @photopath " +
                         " where EmployeeId = @EmployeeId";

                int rc = 0;

                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString))
                {
                    rc = conn.Execute(sqlCmd, new
                    {
                        EmployeeId = e.EmployeeId,
                        lname = e.LastName,
                        fname = e.FirstName,
                        title = e.Title,
                        titlec = e.TitleOfCourtesy,
                        bdate = e.BirthDate,
                        hdate = e.HireDate,
                        address = e.Address,
                        city = e.City,
                        region = e.Region
                        ,
                        pcode = e.PostalCode,
                        country = e.Country,
                        hphone = e.HomePhone,
                        ext = e.Extension,
                        notes = e.Notes,
                        reportsto = e.ReportsTo,
                        photopath = e.PhotoPath
                    });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(e);
            }
        }

        // Not implemented - JC 01/09/2014
        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // Not implemented - JC 01/09/2014
        // POST: Employee/Delete/5
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
