namespace PCI
{
    public class StandUpSlotGenerator
    {
        public List<StandUp> create(TimeSpan start, TimeSpan end, int attendees) {
            var standUps = new List<StandUp>();

            while (TimeSpan.Compare(start, end) == -1)
            {
                StandUp standUp = new StandUp();
                standUp.Start = start;
                standUp.Attendees = attendees;
                standUp.isFree = true;
                standUps.Add(standUp);
                start = start.Add(TimeSpan.FromMinutes(15));

            }
            return standUps;
        }
    }
}