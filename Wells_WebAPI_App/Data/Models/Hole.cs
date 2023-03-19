namespace Wells_WebAPI.Data.Models
{
    public class Hole
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? DrillBlockId { get; set; }
        public DrillBlock? DrillBlock { get; set; }
        public ICollection<HolePoints>? HolePoints { get; set; }
        public double? Depth { get; set; }
    }
}
