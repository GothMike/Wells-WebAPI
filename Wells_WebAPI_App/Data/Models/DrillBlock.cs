namespace Wells_WebAPI.Data.Models
{
    public class DrillBlock
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime UpdateTime { get; set; }
        public ICollection<DrillBlockPoints>? DrillBlockPoints{ get; set; }
        public ICollection<Hole>? Holes { get; set; }
    }
}
