using System;

namespace ProiectMediiSiProgramare.data
{
    //salvare si citire in fisiere 
    public class User
    {
        private String email;
        private String password;

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }
    }
}