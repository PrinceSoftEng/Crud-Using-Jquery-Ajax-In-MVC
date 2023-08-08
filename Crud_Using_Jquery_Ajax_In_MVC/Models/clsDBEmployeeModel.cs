using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Crud_Using_Jquery_Ajax_In_MVC.Models
{
    public class clsDBEmployeeModel
    {
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public List<clsEmployeeModel> ListAllEmployee()
        {
            List<clsEmployeeModel> objAllEmpList=new List<clsEmployeeModel>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from tblEmployee", con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            objAllEmpList.Add(new clsEmployeeModel {
                                EmpId = Convert.ToInt32(sdr["EmpId"]),
                                EmpName = (sdr["EmpName"]).ToString(),
                                Age = Convert.ToInt32(sdr["Age"]),
                                State = (sdr["State"]).ToString(),
                                Country = (sdr["Country"]).ToString()
                            });
                        }
                        return objAllEmpList;
                    }                                            
                }
            }
        }

        public int AddEmployee(clsEmployeeModel objEmpModel)
        {
            int i;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("tblEmployee_sp_CRUDtblEmployee", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@EmpId", objEmpModel.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", objEmpModel.EmpName);
                    cmd.Parameters.AddWithValue("@Age", objEmpModel.Age);
                    cmd.Parameters.AddWithValue("@State", objEmpModel.State);
                    cmd.Parameters.AddWithValue("@Country", objEmpModel.Country);
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return i;           
        }

        public int UpdateEmployee(clsEmployeeModel objEmpModel)
        {
            int i;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("tblEmployee_sp_CRUDtblEmployee", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@EmpName", objEmpModel.EmpName);
                    cmd.Parameters.AddWithValue("@Age", objEmpModel.Age);
                    cmd.Parameters.AddWithValue("@State", objEmpModel.State);
                    cmd.Parameters.AddWithValue("@Country", objEmpModel.Country);
                    cmd.Parameters.AddWithValue("@EmpId", objEmpModel.EmpId);
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return i;
        }

        public int DeleteEmployee(clsEmployeeModel objEmpModel)
        {
            int i;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Delete From tblEmployee where EmpId=@EmpId", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@EmpId", objEmpModel.EmpId);                   
                    i =cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return i;            
        }
    }
}