namespace PCI
{
    public class Person
    {
        public int ContractTimeMinutes  { get; set; }
        public string? Date  { get; set; }
        public bool IsFullDayAbsence  { get; set; }
        public string? Name  { get; set; }
        public string? PersonId  { get; set; }
        public List<Projection>? Projection  { get; set; }

    }
}