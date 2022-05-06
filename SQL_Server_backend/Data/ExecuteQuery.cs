namespace SQL_Server_backend.Data
{
    public class ExecuteQuery
    {
        public List<string> columns = new List<string>();
        public List<List<string>> data = new List<List<string>>();
        public long TimeElapsed { get; set; }
        public int RowsAffected { get; set; }
    }
}
