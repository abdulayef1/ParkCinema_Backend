namespace ParkCinema.Core.Entities;

public class Film_Genre
{
    public int Id { get; set; }

    //Film row
    public int Film_Id { get; set; }
    public Film Film { get; set; } = null!;

    //Genre row
    public int Genre_Id { get; set; }
    public Genre Genre { get; set; } = null!;


}
