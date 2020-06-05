using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginCustomList.Domain;
using UserLoginCustomList.Service;
using UserLoginCustomList.Validator;

namespace UserLoginCustomList
{
    class Program
    {
        public static UserService service = new UserService();

        static void Main(string[] args)
        {
            string username = null, password = null;

            AskLoginCredentials(ref username, ref password);

            LoginValidator validator = LoginValidator.From(username, password, PrintError);
            while (!validator.ValidCredentials())
            {
                AskLoginCredentials(ref username, ref password);

                if (validator.LoginAttemptsExceeded())
                {
                    Console.WriteLine("Надвишен брой опити за login");

                    return;
                }
            }

            User user = service.getUser(username, password);
            if (user == null)
            {
                Console.WriteLine("Несъществуващ потребител!");
                return;
            }

            if (user.Role == UserRole.ADMIN)
            {
                HandleAdminActions();
            }
            else
            {
                Console.WriteLine($"Username={user.Username}");
                Console.WriteLine($"Password={user.Password}");
                Console.WriteLine($"FacultyNumber={user.FacultyNumber}");
                Console.WriteLine($"Role={user.Role}");
                Console.WriteLine($"Created={user.CreatedAt}");
                Console.WriteLine($"ActiveUntil={user.ActiveUnitl}");
            }
        }

        static void AskLoginCredentials(ref string username, ref string password)
        {
            Console.Write("Потребител: ");
            username = Console.ReadLine();

            Console.Write("Парола: ");
            password = Console.ReadLine();
        }

        static void HandleAdminActions()
        {
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Пормяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");

            int actionCode = int.Parse(Console.ReadLine());
            while (actionCode != 0)
            {
                switch (actionCode)
                {
                    case 1:
                        Console.Write("Въведете потребителско име: ");
                        String username = Console.ReadLine();

                        Console.Write("Въведете нова роля: ");
                        UserRole newRole = (UserRole)int.Parse(Console.ReadLine());

                        User user = service.getUser(username);
                        service.changeUserRole(user, newRole);
                        break;
                    case 2:
                        Console.Write("Въведете потребителско име: ");
                        username = Console.ReadLine();


                        Console.Write("Въведете нова дата на активност: ");
                        DateTime expirationTime = DateTime.Parse(Console.ReadLine());

                        user = service.getUser(username);
                        service.updateUserExpiration(user, expirationTime);
                        break;
                    case 4:
                        Console.WriteLine(Logger.ReadActivityLog());
                        break;
                    case 5:
                        Console.WriteLine(Logger.GetCurrentSessionActivities());
                        break;
                    default: break;
                }


                actionCode = int.Parse(Console.ReadLine());
            }

        }

        static void PrintError(string message)
        {
            Console.WriteLine("### ! " + message + " ! ###");
        }
    }
}
