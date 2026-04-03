using MySql.Data.MySqlClient;

public class DB
{
    public static MySqlConnection GetConnection()
    {
        string connStr = "server=localhost;user=root;password=12345;database=qldsv;";
        return new MySqlConnection(connStr);
    }
}