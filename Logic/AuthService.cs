using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLDSV.Models;

public class AuthService
{
    public string Login(string username, string password, out int userId)
    {
        userId = -1;

        using (var context = new QldsvContext())
        {
            var user = context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                userId = user.Id;
                return user.Role;
            }

            return null;
        }
    }
}