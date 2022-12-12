using MarsKapu.Application.Contracts.Services;
using MarsKapu.DataContracts.Enums;
using MarsKapu.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MarsKapu.Services
{
    public class AuthService : IAuthService
    {
        static string Hash(string input)
        {
            using var sha1 = SHA1.Create();
            return Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        public void AddUser(User user, string password)
        {
            if (!AuthenticateUser(user))
            {
                StreamWriter output = new StreamWriter("Repositories/DataBase/Users.txt");
                output.WriteLine(user.ToString() + ";" + Hash(password));
                output.Close();
            }
            else throw new Exception("User is already in the database");
        }

        public bool AuthenticateUser(User user)
        {
            List<User> users = GetUsers();
            return users.Contains(user);
        }

        public void ChangeUser(User user, string password)
        {
            if (AuthenticateUser(user))
            {
                List<User> users = GetUsers();
                int index = 0;
                while (users[index].Id != user.Id)
                {
                    index++;
                }
                users[index].Name = user.Name;
                users[index].UserAuth = user.UserAuth;
                List<string> output = new List<string>();
                foreach (var item in users)
                {
                    output.Add(item.ToString() + ";" + Hash(password));
                }
                File.WriteAllLines("Repositories/DataBase/Users.txt", output);
            }
            else throw new Exception("User is not in the database");
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (StreamReader r = new StreamReader("Repositories/DataBase/Supplies.txt"))
            {
                while (r.EndOfStream == false)
                {
                    string line = r.ReadLine();
                    var data = line.Split(";");
                    int id = int.Parse(data[0]);
                    string name = data[1];
                    Authority auth = new Authority();
                    switch (int.Parse(data[2]))
                    {
                        case 1:
                            auth = Authority.COLONY_LEADER;
                            break;
                        case 2:
                            auth = Authority.TECHNICIAN;
                            break;
                        case 3:
                            auth = Authority.RESEARCHER;
                            break;
                        case 4:
                            auth = Authority.SUPPLYCHAIN_MANAGER;
                            break;
                        case 5:
                            auth = Authority.CITIZEN;
                            break;
                        case 6:
                            auth = Authority.DENIED;
                            break;
                    }
                    users.Add(new User(id, name, auth));
                }
            }
            return users;
        }
        public bool AuthorizeUser(User user, string password)
        {
            List<User> users = GetUsers();
            List<string> passwords = new List<string>();
            using (StreamReader r = new StreamReader("Repositories/DataBase/Users.txt"))
            {
                while (r.EndOfStream == false)
                {
                    string line = r.ReadLine();
                    var data = line.Split(";");
                    passwords.Add(data[3]);
                }
            }
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == user.Id)
                {
                    return passwords[i] == Hash(password);
                }
            }
            return false;
        }
    }
}
