using Microsoft.AspNetCore.Mvc;
using SQL_management_studio.Data;
using System.Data;
using System.Data.SqlClient;

namespace SQL_management_studio_API.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class HomeController : Controller
    {
        private bool isPropper = false;
        private string Username { get; set; }
        private string Password { get; set; }
        private string Server { get; set; } = "(localdb)\\MSSQLLocalDB";
        private string connectionString;
        public HomeController()
        {
            connectionString = "Server=" + Server + ";User Id=" + Username + ";Password=" + Password + ";Trusted_Connection=true;";
        }

        [HttpGet]
        [Route ("Login/{server}/{username}/{password}")]
        public async Task<IActionResult> Login(string server, string username, string password)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = "Server=" + server + ";User Id=" + username + ";Password=" + password + ";Trusted_Connection=true;";
                    con.Open();
                    isPropper = true;

                    Server = server;
                    Username = username;
                    Password = password;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Ok(isPropper);
        }

        [HttpGet]
        [Route ("GetDbList")]
        //[Route ("GetDbList/{server}/{username}/{password}")]
        //public async Task<IActionResult> GetDbList(string server, string username, string password)
        public async Task<IActionResult> GetDbList()
        {
            //Server = server;
            //Username = username;
            //Password = password;
            var listOfDB = new List<string>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listOfDB.Add(dr[0].ToString());
                        }
                    }

                }
            }
            return Ok(listOfDB);
        }

        [HttpGet]
        [Route("GetListOfTablesFromDB/{DbName}")]
        public async Task<IActionResult> GetListOfTablesFromDB(string DbName)
        {
            var list = new List<string>();
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString + "Database=" + DbName + ";";
                con.Open();

                DataTable dt = con.GetSchema("Tables");

                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[2];

                    list.Add(tablename);
                }

                return Ok(list);
            }
        }
        
        [HttpGet]
        [Route ("GetListOfColumnsFromDB/{DbName}/{TableName}")]
        public async Task<IActionResult> GetListOfColumnsFromDB(string DbName, string TableName)
        {
            using (var con = new SqlConnection())
            {
                con.ConnectionString = connectionString + "Database=" + DbName + ";";
                con.Open();

                var list = new List<string>();

                string[] restrictionsColumns = new string[3];
                restrictionsColumns[2] = TableName;
                DataTable schemaColumns = con.GetSchema("Columns", restrictionsColumns);
                foreach (System.Data.DataRow rowColumn in schemaColumns.Rows)
                {
                    list.Add(rowColumn[3].ToString());
                }
                return Ok(list);
            }
        }
    }
}
