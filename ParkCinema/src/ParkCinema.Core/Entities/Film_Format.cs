namespace ParkCinema.Core.Entities;

public class Film_Format
{
    public int Film_Id { get; set; }
    public Film? Film { get; set; }

    public int Format_Id { get; set; }
    public Format? Format { get; set; }
}
