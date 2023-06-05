using System;
using System.Collections.Generic;
using System.IO;
using ProiectMediiSiProgramare.data;

namespace ProiectMediiSiProgramare.repository
{
    // am folosit try-catch pentru tratarea exceptiilor daca nu se deschid fisiere sa imi dea exceptie
    public class ShowRepository
    {
        public static void addShow(Show show)
        {//Adaug cate un show pe rand si am numele si cate locuri sunt valabile pentru showul respectiv

            try
            {
                string filePath = "C:\\Users\\cristian\\Desktop\\ProiectCristian\\ProiectMediiSiProgramare\\ProiectMediiSiProgramare\\repository\\shows.txt";
                string newShow = show.Name + ";" + show.AvailableSeats + Environment.NewLine;
                File.AppendAllText(filePath, newShow);
                
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error opening the file: ");
                Console.WriteLine(e.Message);
            }
        }

        public static void deleteUnavailableShows()
        {
            //Aici sterge deodata toate showurile care nu au locuri disponibile adica au 0 trecut
            try
            {
                string filePath = "C:\\Users\\cristian\\Desktop\\ProiectCristian\\ProiectMediiSiProgramare\\ProiectMediiSiProgramare\\repository\\shows.txt";
                var lines = File.ReadLines(filePath);
                List<Tuple<String, String>> shows = new List<Tuple<string, string>>(); //aici am folosit list;Din fiecare tuple luam datele si le scriem in fisier
                foreach (var line in lines)
                {
                    String[] credentials = line.Split(';');
                    if (Int32.Parse(credentials[1]) > 0)
                    {
                        shows.Add(new Tuple<string, string>(credentials[0], credentials[1]));
                    }
                }
                File.WriteAllText(filePath, "");
                foreach (var tuple in shows)
                {
                    string newShow = tuple.Item1 + ";" + tuple.Item2 + Environment.NewLine;
                    File.AppendAllText(filePath, newShow);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error opening the file: ");
                Console.WriteLine(e.Message);
            }
            
        }

        public static int getAvailableSeatsForShow(String name)
        {
            //Getavailableseatsfor show asta e doar pentru useri si aici verific cate seats sunt disponibile
            //iar daca sunt disp se modifica in modifyshow locurile disponibile la show
            //Verifica daca sunt locuri disponibile cate vrea userul 
            try
            {
                string filePath = "C:\\Users\\cristian\\Desktop\\ProiectCristian\\ProiectMediiSiProgramare\\ProiectMediiSiProgramare\\repository\\shows.txt";
                var lines = File.ReadLines(filePath);
                foreach (var line in lines)
                {
                    String[] credentials = line.Split(';');
                    if (credentials[0].Equals(name))
                        return Int32.Parse(credentials[1]);
                }

                return -1;
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error opening the file: ");
                Console.WriteLine(e.Message);
            }

            return -1;
        }

        public static void modifyShow(Show show, int requestedSeats)
        {
            //Tot asa fac lista cu toate showurile pentru ca nu pot modifica un singur show
            //Daca am gasit showul pe care vreau sa il modific se calculeaza pentru locurile disp noua valoare 
            //
            try
            {
                string filePath = "C:\\Users\\cristian\\Desktop\\ProiectCristian\\ProiectMediiSiProgramare\\ProiectMediiSiProgramare\\repository\\shows.txt";
                var lines = File.ReadLines(filePath);
                List<Tuple<String, String>> shows = new List<Tuple<string, string>>();
                foreach (var line in lines)
                {
                    String[] credentials = line.Split(';');
                    if (credentials[0] == show.Name)
                    {
                        shows.Add(new Tuple<string, string>(credentials[0], (Int32.Parse(credentials[1])-requestedSeats).ToString()));
                    }
                    else
                    {
                        shows.Add(new Tuple<string, string>(credentials[0], credentials[1]));
                    }
                }
                File.WriteAllText(filePath, "");
                foreach (var tuple in shows)
                {
                    string newShow = tuple.Item1 + ";" + tuple.Item2 + Environment.NewLine;
                    File.AppendAllText(filePath, newShow);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error opening the file: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}