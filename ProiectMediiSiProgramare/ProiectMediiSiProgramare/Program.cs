using System;
using ProiectMediiSiProgramare.data;
using ProiectMediiSiProgramare.repository;

//Daca esti admin poti adauga un nou show sau poti sa stergi toate showrile care nu mai sunt valabile
//Daca esti user normal poti sa cumperi tickete. Iti scri numele showului la care vrei sa mergi si cate tikete vrei si apoi verifica daca sunt locuri atunci el iti da tiket apoi scade din show locurile altfel iti zice ca nu sunt suficiente locuri
//Si daca ma duc pe register la fel creez user nou

namespace ProiectMediiSiProgramare
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.LogIn\n2.Register");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Write your username:");
                    var username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password = Console.ReadLine();

                    if (UserRepository.getUsersFromFile(new User(username, password)))
                    {
                        if (AdminUser.checkIfAdmin(new User(username, password)))
                        {
                            while (true)
                            {
                                Console.WriteLine("1.Add show\n2.Delete shows");
                                var inputAdmin = Console.ReadLine();
                                if (inputAdmin == "1")
                                {
                                    Console.WriteLine("Write show name:");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("Enter available seats:");
                                    var seats = Console.ReadLine();
                                    ShowRepository.addShow(new Show(name, Int32.Parse(seats)));
                                }
                                else if (inputAdmin == "2")
                                {
                                    ShowRepository.deleteUnavailableShows();
                                }
                                else
                                {
                                    Console.WriteLine("This command does not exists!");

                                }
                            }
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("1.Buy ticket");
                                var inputUser = Console.ReadLine();
                                if (inputUser == "1")
                                {
                                    Console.WriteLine("Write show name:");
                                    var showName = Console.ReadLine();
                                    Console.WriteLine("How many seats do you want:");
                                    var requestedSeats = Console.ReadLine();
                                    var showSeats = ShowRepository.getAvailableSeatsForShow(showName);
                                    if (TicketRepository.getTicket(new Ticket(new Show(showName, showSeats), new User(username, password), Int32.Parse(requestedSeats))))
                                    {
                                        ShowRepository.modifyShow(new Show(showName, showSeats), Int32.Parse(requestedSeats));
                                        Console.WriteLine("You have successfully bought the tickets!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("There are not enough seats left!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This command does not exists!");

                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your username or password is incorrect, try again !!!");
                    }
                }

                else if (input == "2")
                {

                    Console.WriteLine("Enter your username:");
                    var username = Console.ReadLine();

                    Console.WriteLine("Enter your password:");
                    var password = Console.ReadLine();
                    
                    UserRepository.addUser(new User(username, password));

                }
                
                else
                {
                    Console.WriteLine("This command does not exists!");

                }

            }
        }

            

    }
}


