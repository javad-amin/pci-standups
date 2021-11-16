using System.Text.Json;

namespace PCI
{
    public class JsonConsumer : IJsonConsumer
    {
        public int teamSize { get; set; }
        public List<StandUp> ExtractSchedule(Schedule schedule)
        {
            List<StandUp> standUps = new List<StandUp>();
            
            this.teamSize = schedule.ScheduleResult["Schedules"].Count;

            foreach (Person person in schedule.ScheduleResult["Schedules"]) {

                foreach (Projection projection in person.Projection) {

                    string startTimeStamp = projection.Start.Substring(6, 13);
                    long epoch = Convert.ToInt64(startTimeStamp);
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(epoch);
                    TimeSpan start = dateTimeOffset.DateTime.TimeOfDay;
                    TimeSpan end = start.Add(TimeSpan.FromMinutes(projection.minutes));
                    
                    List<StandUp> personsStandUps = new StandUpSlotGenerator().create(start, end, 1);
                    
                    foreach (StandUp standUp in personsStandUps) {
                        standUps.Add(standUp);
                    }
                }
            }   

            return standUps;
        }
    }

}