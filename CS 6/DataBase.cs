namespace DataBase;

using Admin;
using User;

internal class DataBase
{
    public static Admin? admin;
    public static User[]? user;

    public DataBase(Admin? _admin, User[]? _user)
    {
        admin = _admin;
        user = _user;
    }

    public (bool?, int) LogIn(ref string username, ref string password)
    {
        if (admin is not null && admin?.name?.Length == username.Length)
            if (admin?.password?.Length == password.Length)
                if (admin.name == username)
                    if (admin.password == password)
                        return (true, 0);


        for (int i = 0; i < user?.Length; i++)
            if (user is not null && user[i]?.name?.Length == username.Length)
                if (user[i]?.password?.Length == password.Length)
                    if (user[i].name == username)
                        if (user[i].password == password)
                            return (false, i);
                    
        return (null, -1);
    }



}

