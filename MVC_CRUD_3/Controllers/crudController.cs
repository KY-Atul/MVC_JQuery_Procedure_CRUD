using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using MVC_CRUD_3.Models;

namespace MVC_CRUD_3.Controllers
{
    public class crudController : Controller
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        // GET: crud
        public ActionResult CRUD_VIEW()
        {
            return View();
        }

        public void ins (MClass obj)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_student", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ops", "insert");

            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@address", obj.address);
            cmd.Parameters.AddWithValue("@age", obj.age);

            cmd.ExecuteNonQuery();
            cnn.Close();

        }


        public string dis() 
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_student", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ops", "display");

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            cnn.Close();

            return (JsonConvert.SerializeObject(dt));
        
        }

        public void del(MClass obj)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_student", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ops", "delete");

            cmd.Parameters.AddWithValue("@student_id", obj._id);

            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public string edi(MClass obj)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_student", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ops", "edit");

            cmd.Parameters.AddWithValue("@student_id", obj._id);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            cnn.Close();

            return (JsonConvert.SerializeObject(dt));

        }


        public void upd(MClass obj) 
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_student", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ops", "update");

            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@address", obj.address);
            cmd.Parameters.AddWithValue("@age", obj.age);
            cmd.Parameters.AddWithValue("@student_id", obj._id);

            cmd.ExecuteNonQuery();

            cnn.Close();
        
        }

    }
}