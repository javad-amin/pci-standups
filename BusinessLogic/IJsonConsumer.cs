namespace PCI
{
    public interface IJsonConsumer
    {        
        List<StandUp> ExtractSchedule(Schedule schedule);
    }
}