using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Data;
using RAAST_web.Models;

namespace RAAST_web.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult AllEditors()
        {
            List<Editor> editors = new List<Editor>();

            NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=Editor;User Id=postgres;Password=Yannick01");
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            command.CommandText = "select * from Editor";

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Editor editor = new Editor();
                editor.Id = Convert.ToInt32(reader["Id"]);
                editor.fullName = reader["fullName"].ToString();
                editor.email = reader["email"].ToString();
                editor.passWord = reader["passWord"].ToString();

                editors.Add(editor);
            }

            return View(editors);
        }



        // GET: Editor
        public ActionResult AddEditor()
        {
            return View();
        }
        public ActionResult Verify()
        {
            return View("Success");
        }
    }
}