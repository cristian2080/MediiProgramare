using ProiectMediiSiProgramare.data;

namespace ProiectMediiSiProgramare.repository
{
    public class TicketRepository

    {
        public static bool getTicket(Ticket ticket)
        {
            if (ticket.SeatsRequested <= ticket.Show.AvailableSeats)
            {

                return true;
            }
            return false;
        }
    }
}
//am show ca parametru si pot vedea cate locuri valabile are
