#region [ Using ]

using System;

#endregion

namespace TvMazeScraper.WebApi.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Id { get; set; }
    }
}