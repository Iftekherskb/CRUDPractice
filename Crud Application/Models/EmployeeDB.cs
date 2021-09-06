using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Crud_Application.Models
{
    public class EmployeeDB
    {
        
            //declare connection string  
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //Return list of all Employees  
            public List<Employee> ListAll()
            {
                List<Employee> lst = new List<Employee>();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SelectEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new Employee
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Name = rdr["Name"].ToString(),
                            Age = Convert.ToInt32(rdr["Age"]),
                            State = rdr["State"].ToString(),
                            Country = rdr["Country"].ToString(),
                        });
                    }
                    return lst;
                }
            }

            //Method for Adding an Employee  
            public int Add(Employee emp)
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", emp.Id);
                    com.Parameters.AddWithValue("@Name", emp.Name);
                    com.Parameters.AddWithValue("@Age", emp.Age);
                    com.Parameters.AddWithValue("@State", emp.State);
                    com.Parameters.AddWithValue("@Country", emp.Country);
                    com.Parameters.AddWithValue("@Action", "Insert");
                    i = com.ExecuteNonQuery();
                }
                return i;
            }

            //Method for Updating Employee record  
            public int Update(Employee emp)
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", emp.Id);
                    com.Parameters.AddWithValue("@Name", emp.Name);
                    com.Parameters.AddWithValue("@Age", emp.Age);
                    com.Parameters.AddWithValue("@State", emp.State);
                    com.Parameters.AddWithValue("@Country", emp.Country);
                    com.Parameters.AddWithValue("@Action", "Update");
                    i = com.ExecuteNonQuery();
                }
                return i;
            }

            //Method for Deleting an Employee  
            public int Delete(int Id)
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("DeleteEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", Id);
                    i = com.ExecuteNonQuery();
                }
                return i;
            }

        public List<Country> ListCountry()
        {
            List<Country> Countrylist = new List<Country>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string sql = "select * from Country";
                SqlCommand com = new SqlCommand(sql, con);
                /*com.CommandType = CommandType.StoredProcedure;*/
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Countrylist.Add(new Country
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                    });
                }
                return Countrylist;
            }
        }
    }
    
}