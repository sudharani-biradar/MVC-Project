using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
using MVCWebApp.Models;
using System.Data;
using System.Data.SqlClient;

//using Microsoft.Extensions.Configuration;
namespace MVCWebApp.Controllers
{
    public class NewRegisterController : Controller
    {
        private readonly IConfiguration _configuration;

        public NewRegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

         [HttpPost]
        public IActionResult Index( User_Register register)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn=new SqlConnection(myDb1ConnectionString);
            using (SqlConnection con = new SqlConnection(myDb1ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_NewRegister", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = register.Username;
                    cmd.Parameters.AddWithValue("@Pasword", SqlDbType.VarChar).Value = register.Pasword;
                    cmd.Parameters.AddWithValue("@Repassword", SqlDbType.VarChar).Value = register.Repassword;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = register.EmailId;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = register.Gender;
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //string insertquery= "insert into [dbo].[User_Register] (Username,Password,Repassword,EmailId,Gender) values (@Username,@Password,@Repassword,@EmailId,@Gender)";
            //SqlCommand sqlcmmd =new  SqlCommand(insertquery,conn);
            //conn.Open();
            //sqlcmmd.Parameters.AddWithValue("@Username", register.Username);
            //sqlcmmd.Parameters.AddWithValue("@Password", register.Password);
            //sqlcmmd.Parameters.AddWithValue("@Repassword", register.Repassword);
            //sqlcmmd.Parameters.AddWithValue("@EmailId", register.EmailId);
            //sqlcmmd.Parameters.AddWithValue("@Gender", register.Gender);
            //sqlcmmd.ExecuteNonQuery();
            //conn.Close();
           
            return View();
        }
    }
}
