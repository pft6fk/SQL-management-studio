namespace SQL_Server_backend.Data
{
    public class ExecuteQuery
    {
        public List<string> Columns  { get; set; }
        public List<List<string>> Data { get; set; }
        public long TimeElapsed { get; set; }
        public int RowsAffected { get; set; }
    }
}
