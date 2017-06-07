namespace SQLite
{
    public class Login
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(25)]
        public string username { get; set; }
        [MaxLength(15)]
        public string password { get; set; }
       
    }
}