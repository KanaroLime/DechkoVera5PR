using _5pr.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HashPassword.Hash;

namespace _5pr
{
    internal class Helper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите отчество если есть:");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            string hashedPassword = HashHelper.HashPassword(password);
            Console.WriteLine("Хешированный пароль: " + hashedPassword);

            Console.WriteLine("Введите роль, где 1-администратор, 2-уборщик, 3-повар, 4-сушеф, 5-шеф, 6-официант, 7-бармен:");
            string roleCode = Console.ReadLine();

            Console.WriteLine("Введите номер телефона (11 цифр):");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Введите ID пользователя:");
            string UserCode = Console.ReadLine();

            RegisterUser(name, surname, patronymic, login, password, roleCode, phoneNumber, UserCode);
            Console.WriteLine("Пользователь успешно добавлен.");
        }

        public static void RegisterUser(string name, string surname, string patronymic, string login, string password, string roleCode, string phoneNumber, string UserCode)
        {
            {
                using (var context = new РесторанEntities2())
                {
                    try
                    {
                        string hashedPassword = HashHelper.HashPassword(password);

                        User newUser = new User
                        {
                            Login = login,
                            Password = hashedPassword,

                        };
                        context.User.Add(newUser);
                        context.SaveChanges();
                        int parsedRoleCode = int.Parse(roleCode);

                        Staff newStaff = new Staff
                        {
                            Name = name,
                            Surname = surname,
                            Patronymic = patronymic,
                            Role_code = parsedRoleCode,
                            Phone_number = phoneNumber,
                            User_code = newUser.User_code
                        };
                        context.Staff.Add(newStaff);
                        context.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        foreach (var validationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка формата: проверьте что значения roleCode и staffCode являются числамиь");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Ошибка: значения roleCode или staffCode слишком велики или малы для типа Int32.");
                    }
                }
            }

        }
    }
}

