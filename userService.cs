using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class userService
    {
        private string[,] data, histories;
        private string email, password, roles = "", book1 = "", book2 = "", date = "";

        public userService(string emails, string passwords)
        {
            email = emails;
            password = passwords;
            data = new string[2, 3] {
                {"elmarkelompok53@gmail.com", "12345", "superadmin" },
                {"abimanyukelompok53@gmail.com", "12345", "user"  }
            };
            histories = new string[2, 4] {
                { "elmarkelompok53@gmail.com", "Fisika Dasar", "Dasar Komputer dan Pemograman", "25-04-2020" },
                { "abimanyukelompok53@gmail.com", "Dasar Komputer dan Pemograman", "Konsep Jaringan Kelompok", "25-04-2020"  }
            };
        }
        
        public void login()
        {
            var (status, role) = checkCredentials();
            if (status == true)
            {
                Console.WriteLine("\nWelcome " + role);
                Console.WriteLine("Logged it as user email: " + email);
                Console.WriteLine("\n" + email);
                Console.WriteLine("" + book1);
                Console.WriteLine("" + book2);
                Console.WriteLine("Tanggal Pinjaman : " + date);
            }
            else
            {
                Console.WriteLine("\nInvalid Login");
            }
        }
        private (bool, string) checkCredentials()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == email && data[i, 1] == password)
                {
                    book1 = histories[i, 1];
                    book2 = histories[i, 2];
                    date  = histories[i, 3];
                    roles = data[i, 2];
                    return (true, roles);
                }
            }
            return (false, roles);
        }
    }
}