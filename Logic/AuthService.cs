public class AuthService
{
    public static string Login(string username, string password, out int userId)
    {
        userId = -1;

        var reader = UserDB.Login(username, password);

        if (reader.Read())
        {
            userId = Convert.ToInt32(reader["id"]);
            return reader["role"].ToString();
        }

        return null;
    }
}