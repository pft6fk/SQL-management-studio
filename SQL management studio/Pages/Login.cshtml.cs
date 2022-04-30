using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace SQL_management_studio.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=" + ";User Id=" + ";Password=" + ";Trusted_Connection=true";
                connection.Open();
                Console.WriteLine("connection established"); 
            }

        }
    }
}
