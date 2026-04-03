// DAL/UserDAO.cs
using MySql.Data.MySqlClient;
using System.Data.Common;

public class UserDB
{
    public static MySqlDataReader Login(string username, string password)
    {
        var conn = DB.GetConnection();
        conn.Open();

        string query = "SELECT * FROM users WHERE username=@u AND password=@p";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@u", username);
        cmd.Parameters.AddWithValue("@p", password);

        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }
}