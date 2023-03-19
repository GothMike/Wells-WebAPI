namespace Wells_WebAPI.Data.Models
{
    public class HolePoints
    {
        public int Id { get; set; }
        public int HoleId { get; set; }
        public Hole Hole { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
