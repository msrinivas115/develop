using System;
using System.Collections.Generic;

namespace AESAlgoritham
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = string.Empty;
            Console.Write("Enter Connection String: ");
            connectionstring = @"uid=sa;password=Password123;data source=(localdb)\LocalDB;initial catalog=UserManagement;pooling=true;";
            ConnectionEncrypt(connectionstring);
            //ConnectionDecrypt();
        }

        private static void ConnectionEncrypt(string userName)
        {
            string encryptStr = AES.Encrypt(userName, new byte[] { 1, 1, 3, 6, 2, 5, 4, 7 });
            Console.WriteLine(encryptStr);
            Console.WriteLine("Decrypt Password: Press Enter");
            Console.ReadLine();
            ConnectionDecrypt(encryptStr);
        }

        private static void ConnectionDecrypt(string userName)
        {
            string decryptPassword = AES.Decrypt(userName, new byte[] { 1, 1, 3, 6, 2, 5, 4, 7 });
            Console.WriteLine(decryptPassword);
            Console.ReadLine();
        }

        private static void ConnectionDecrypt()
        {
            List<string> passwords = new List<string>();
            passwords.Add("4HazYmSe8qAVsgqbOfM9QqYuZxAVglU0ry77M7k5TeJhmmg+Amoomfb6n9F/06Gp");
            string decryptPassword = string.Empty;
            foreach (string s in passwords)
            {
                decryptPassword = AES.Decrypt(s, new byte[] { 1, 1, 3, 6, 2, 5, 4, 7 });
                Console.WriteLine(decryptPassword);
            }
            Console.ReadLine();
        }
    }
}
