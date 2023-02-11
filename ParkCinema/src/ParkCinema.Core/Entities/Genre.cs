using ParkCinema.Core.Interfaces;

namespace ParkCinema.Core.Entities;

public class Genre : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }

    //
    public ICollection<Film_Genre> Film_Genres { get; set; } = null!;
}
