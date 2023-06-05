namespace ProiectMediiSiProgramare.data
    //Am compozitie folosesc show si user; Si am getter/setter 

{
    public class Ticket
    {
        private Show show;
        private User user;
        private int seatsRequested;

        public Ticket(Show show, User user, int seatsRequested)
        {
            this.show = show;
            this.user = user;
            this.seatsRequested = seatsRequested;
        }

        public Show Show
        {
            get => show;
            set => show = value;
        }

        public User User
        {
            get => user;
            set => user = value;
        }

        public int SeatsRequested
        {
            get => seatsRequested;
            set => seatsRequested = value;
        }
    }
}