using Crud_Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Application.Controllers
{
    public class HomeController : Controller
    {
        string sqlCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        EmployeeDB empDB = new EmployeeDB();
        List<object> returnData = new List<object>();
        // GET: Home
        public ActionResult Index()
        {
            

            return View();

            
        }
        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.Id.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllListCountry()
        {
            return Json(empDB.ListCountry(), JsonRequestBehavior.AllowGet);
        }

        /*public IEnumerable<object> CountryLoad()
        {
            SqlConnection con = new SqlConnection(sqlCon);
           
            string sql = "select distinct Id,Name from Country ";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        returnData.Add(new
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return returnData;
        }*/
    }
}