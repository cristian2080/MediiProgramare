namespace ProiectMediiSiProgramare.data
    // am folosit mostenire; el preia emailul si parola din user si vf daca e admin
{
    public class AdminUser : User
    {
        public AdminUser(string email, string password) : base(email, password)
        {
            Email = email;
            Password = password;
        }

        public static bool checkIfAdmin(User user)
        {
            if (user.Email == "admin" && user.Password == "admin") return true;
            return false;
        }
        
        //can do addShow and deleteShow

    }
}

