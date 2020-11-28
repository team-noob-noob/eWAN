using System;
using System.Collections.Generic;
using eWAN.Domains.User;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.EnrolledSubject;
using eWAN.Domains.Role;
using eWAN.Domains.Section;

namespace eWAN.Infrastructure.Database.Entities
{
    public class User : Domains.User.User, IUser
    {
        public User() {}
        public User(
            string Username,
            string Password, 

            string Email, 
            string PhoneNumber, 

            string FirstName,
            string MiddleName,
            string LastName,

            string Address)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Address = Address;
        }

        public override string Username { get; set; }
        public override string Password { get; set; }
        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public override string FirstName { get; set; }
        public override string MiddleName { get; set; }
        public override string LastName { get; set; }
        public override string Address { get; set; }
    }
}

