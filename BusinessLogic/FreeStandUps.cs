namespace PCI
{
    public class FreeStandUps
    {
        public List<StandUp> GetFreeStandUps(Schedule schedule, int minimumAttendees)
        {
            TimeSpan opening = new TimeSpan(7,0,0);
            TimeSpan closing = new TimeSpan(22,0,0);

            JsonConsumer consumer = new JsonConsumer();
            List<StandUp> scheduledSlots = consumer.ExtractSchedule(schedule);
            int teamSize = consumer.teamSize; 
            List<StandUp> availableSlots = new StandUpSlotGenerator().create(opening, closing, teamSize);

            foreach (StandUp scheduled in scheduledSlots) {
                foreach (StandUp slot in availableSlots) {
                    if (TimeSpan.Compare(slot.Start, scheduled.Start) == 0) {
                        slot.Absents += 1;
                        slot.Attendees = teamSize - slot.Absents;
                    }
                }
            }

            foreach (StandUp slot in availableSlots) {
                if (slot.Attendees < minimumAttendees) {
                    slot.isFree = false;
                }
            }
            
            return availableSlots;
        }
    }
}