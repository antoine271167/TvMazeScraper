#region [ Using ]

using System;
using TvMazeScraper.Domain.Interfaces;

#endregion

namespace TvMazeScraper.Domain.Entities
{
    public class Person : IEntity<int>
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Id { get; set; }
    }
}