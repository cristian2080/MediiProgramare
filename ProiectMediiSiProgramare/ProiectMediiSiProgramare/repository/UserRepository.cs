using System;
using System.IO;
using System.Linq;
using ProiectMediiSiProgramare.data;

namespace ProiectMediiSiProgramare.repository
// am folosit try-catch pentru tratarea exceptiilor daca nu se deschid fisiere sa imi dea exceptie
{
    public class UserRepository
    {
        public static bool getUsersFromFile(User user)
        {
            try
            {

                string filePath = "C:\\Users\\cristian\\Desktop\\ProiectCristian\\ProiectMediiSiProgramare\\ProiectMediiSiProgramare\\repository\\users.txt";

                /*var lines = File.ReadLines(filePath);
                foreach (var line in lines)
                {
                    String[] credentials = line.Split(';');
                    if (credentials[0].Equals(user.Email) && credentials[1].Equals(user.Password)) return true;
                }*/
                //Aici am folosit line ;Aici selectez din lista mea de user un singur user cu emailul dat ca si parametru
                //Asta verifica daca chiar am datele in fisier altfel daca nu imi returneaza ca nu este

                        var item = (from u in (from line in File.ReadAllLines(filePath)
                        let columns = line.Split(';')
                        where columns[0] == user.Email
                        select new
                        {
                            Email = columns[0].Trim(),
                            Password = columns[1].Trim()
                        })
                    select u);
                if (item != null && item.Any())
                {
                    if (item.ElementAt(0).Email == user.Email && item.ElementAt(0).Password == user.Password)
                        return true;
                }

                return false;
                
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error opening the file: ");
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public static void addUser(User user)
        {
            try
            {
                string filePath = "C:\\Users\\cristian\\Desktop\\ProiectCristian\\ProiectMediiSiProgramare\\ProiectMediiSiProgramare\\repository\\users.txt";
                string newUser = user.Email + ";" + user.Password + Environment.NewLine;
                File.AppendAllText(filePath, newUser);
                
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error opening the file: ");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}