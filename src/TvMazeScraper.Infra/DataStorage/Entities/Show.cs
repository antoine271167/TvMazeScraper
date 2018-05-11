#region [ Using ]

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace TvMazeScraper.Infra.DataStorage.Entities
{
    [Table(nameof(Show), Schema = SchemaNames.TvMazeSchema)]
    public class Show
    {
        [Key] public int Key { get; set; }
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Cast { get; set; }
    }
}