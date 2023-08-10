namespace AppServer.Models
{
    public class DBRecipeSuccessData
    {
        public int ID { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public List<string>? Images { get; set; } = new List<string>();

        public List<UsedDate>? UsedDates { get; set; } = new List<UsedDate>();
    }
}
