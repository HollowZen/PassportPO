﻿
namespace PassportPO.Model
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Employee(string? name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
    }
}
