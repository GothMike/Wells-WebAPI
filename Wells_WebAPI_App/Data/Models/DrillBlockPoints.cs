
namespace Wells_WebAPI.Data.Models
{
    public class DrillBlockPoints
    {
        public int Id { get; set; }
        public int? DrillBlockId { get; set; }
        public DrillBlock? DrillBlock { get; set; }
        public int? Sequence { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
    }
}
