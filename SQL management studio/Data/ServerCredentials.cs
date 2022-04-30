namespace SQL_management_studio.Data
{
    public class ServerCredentials
    {
        public string Server { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

/*//for retrieving list of databases
 * using (SqlConnection con = new SqlConnection())
   {
        con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;User Id=user;Password=password;Trusted_Connection=true;";
        con.Open();

        List<string> list = new List<string>();
        // Set up a command with the given query and associate
        // this with the current connection.
        using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
        {
            using (IDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    list.Add(dr[0].ToString());
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }*/
