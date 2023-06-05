using System;
//Am folosit incapsulare pentru ca am atributele privat si folosesc getter si setter; si salvare si citire in fisier
namespace ProiectMediiSiProgramare.data
{
    public class Show
    {
        private String name;
        private int availableSeats;

        public Show(string name, int availableSeats)
        {
            this.name = name;
            this.availableSeats = availableSeats;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int AvailableSeats
        {
            get => availableSeats;
            set => availableSeats = value;
        }
    }
}