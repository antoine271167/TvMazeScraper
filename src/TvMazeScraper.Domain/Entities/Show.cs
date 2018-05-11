#region [ Using ]

using TvMazeScraper.Domain.Interfaces;

#endregion

namespace TvMazeScraper.Domain.Entities
{
    public class Show : IEntity<int>
    {
        public string Name { get; set; }
        public Person[] Cast { get; set; }
        public int Id { get; set; }
    }
}