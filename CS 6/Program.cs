
using System.Text;
using System.Threading;


namespace CS_6;

using Admin;
using User;
using Post;
using Notify;
using DataBase;

internal class Program
{

    static void Main(string[] args)
    {
        Post post = new("qacmaq", 23, 33);
        List<Post>? p_arr = new();
        p_arr?.Add(post);
        Notify n = new("adsbadvdjsc", "adas", new(2022, 12, 31));
        List<Notify>? n_arr = new();
        n_arr.Add(n);
        Admin admin = new Admin("admin", "admin123", 23, p_arr, n_arr);


        User u1 = new("user1", "54321", 26);
        User u2 = new("user2", "4321", 36);
        User u3 = new("user3", "321", 16);
        User u4 = new("user4", "21", 46);
        User u5 = new("user5", "1", 56);
        User[] users_arr = new[] { u1, u2, u3, u4, u5 };

        (bool?, int) logIn;
        bool flag;
        string? name, password;
        DataBase dataBase = new(admin, users_arr);
        while (true)
        {
            flag = true;
            Console.WriteLine("\t\t\tWelcome to our app\n");
            Console.Write("Enter your name : ");
            name = Console.ReadLine();
            Console.Write("Enter your password : ");
            password = Console.ReadLine();

            logIn = dataBase.LogIn(ref name!, ref password!);
            if (logIn.Item1 is true)
            {
                Console.WriteLine($"Welcome to your account Dear {admin?.name}....)");
                Thread.Sleep(1500);
                Console.Clear();

                while (flag)
                {
                    Console.WriteLine("1 -> View all Posts");
                    Console.WriteLine("2 -> View all Notifications");
                    Console.WriteLine("3 -> Add new Post");
                    Console.WriteLine("0 -> Exit");

                    Console.WriteLine("\nEnter the number of your choice : ");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            for (int i = 0; i < admin?.post?.Count; i++)
                                Console.WriteLine(admin.post[i]);

                            Console.WriteLine("\n\nTo return menu Press \"Enter\" keyword ");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                            
                            Console.Clear();
                            break;
                        case ConsoleKey.D2:
                            for (int i = 0; i < admin?.notify?.Count; i++)
                                Console.WriteLine(admin.notify[i]);

                            Console.WriteLine("\n\nTo return menu Press \"Enter\" keyword ");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

                            Console.Clear();
                            break;
                        case ConsoleKey.D3:
                            admin?.post?.Add(admin.CreatePosts());
                            Console.WriteLine("Successfully added");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                        case ConsoleKey.D0:
                            Console.WriteLine("\n\nSEE YOU SOON");
                            Thread.Sleep(1500);
                            Console.Clear();
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("\n\nWrong choice....");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                    }
                }
            }
            else if (logIn.Item1 is false)
            {
                Console.WriteLine($"Welcome to your account Dear {users_arr[logIn.Item2]?.name}....)");
                Thread.Sleep(1500);
                Console.Clear();

                while (flag)
                {
                    Console.WriteLine("1 -> View all Posts");
                    Console.WriteLine("2 -> Like Post");
                    Console.WriteLine("0 -> Exit");

                    Console.WriteLine("\nEnter the number of your choice : ");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            for (int i = 0; i < admin?.post?.Count; i++)
                                Console.WriteLine(admin.post[i]);

                            Console.WriteLine("\n\nTo return menu Press \"Enter\" keyword ");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

                            Console.Clear();
                            break;
                        case ConsoleKey.D2:
                            Console.Write("Enter Post ID to Like : ");
                            if (Guid.TryParse(Console.ReadLine(), out Guid id))
                            {
                                bool checker = false;
                                uint viewCount = 0;
                                for (int i = 0; i < admin?.post?.Count; i++)
                                    if (admin.post[i].id == id)
                                    {
                                        checker = true;
                                        admin.post[i].likeCount++;
                                        viewCount = admin.post[i].viewCount++;
                                        break;
                                    }

                                if (checker)
                                {
                                    Console.WriteLine("Post liked...");
                                    string text = $"Post Liked by {users_arr[logIn.Item2].name} \nPost view count increased {viewCount + 1}";
                                    Notify notify = new Notify(text, users_arr[logIn.Item2].name, DateTime.Now);
                                    admin?.notify?.Add(notify);
                                }
                                else
                                    Console.WriteLine("Post couldn't be found");
                            }
                            else
                            {
                                Console.WriteLine("Entered ID was wrong");
                                Thread.Sleep(1500);
                                Console.Clear();
                            }

                            Console.WriteLine("\n\nTo return menu Press \"Enter\" keyword ");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

                            Console.Clear();
                            break;
                        case ConsoleKey.D0:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("\n\nWrong choice....");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong name or password.Please, check your infos and try again...");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

    }
}

