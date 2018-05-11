namespace TvMazeScraper.WebApi.Models
{
    public class ShowModel
    {
        public string Name { get; set; }
        public PersonModel[] Cast { get; set; }
        public int Id { get; set; }
    }
}