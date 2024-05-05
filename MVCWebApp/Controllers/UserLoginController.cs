using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVCWebApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVCWebApp.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult  Index(User_Login reg)
        {


            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(myDb1ConnectionString);
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myDb1ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UserLogin", con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = reg.Username;
                    //cmd.Parameters.AddWithValue("@Pasword", SqlDbType.VarChar).Value = reg.Pasword;
                    //con.Open();
                  
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = reg.Username;
                        cmd.Parameters.AddWithValue("@Pasword", SqlDbType.VarChar).Value = reg.Pasword;
                        var outputParameter = new SqlParameter
                        {
                              ParameterName = "@rowcount",
                              SqlDbType = SqlDbType.Int,
                              Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParameter);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        if(outputParameter.Value is 0) 
                        {
                              TempData["Message"] = "You are not Registered.Please sign up.";
                        }
                }
            }
            return View();
        
        }
    }
}
