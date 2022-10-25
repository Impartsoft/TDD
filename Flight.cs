namespace TDD
{
    public class Flight
    {
        public int SeatCapacity { get; private set; }

        public Flight(int seatCapacity)
        {
            this.SeatCapacity = seatCapacity;
        }

        public object Book(string mail, int bookingSeat)
        {
            if (SeatCapacity < bookingSeat)
                return new OverbookingError();

            if (bookingSeat <= 0)
                return new InvalidbookingError();

            SeatCapacity -= bookingSeat;
            return null;
        }
    }
}