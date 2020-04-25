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
            }
            else
            {
                Console.WriteLine("\nInvalid Login");
            }
        }
        public void Record()
        {
            var (status, book1) = checkRecord();
            if (status == true)
            {
                Console.WriteLine("\n"+ email ,"Meminjam buku ");
                Console.WriteLine("" + book1);
                Console.WriteLine("" + book2);
                Console.WriteLine("Tanggal peminjaman : " + date);
            }
        }
        private (bool, string) checkCredentials()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == email && data[i, 1] == password)
                {
                    roles = data[i, 2];
                    return (true, roles);
                }
            }
            return (false, roles);
        }
        private (bool, string) checkRecord()
        {
            for (int a = 0; a < histories.GetLength(0); a++)
            {
                if (histories[a, 0] == email)
                {
                    book1 = histories[a, 1];
                    book2 = histories[a, 2];
                    date = histories[a, 3];
                    return (true, book1);
                }
            }
            return (false, book1);
        }
    }
}