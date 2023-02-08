﻿using ParkCinema.Core.Interfaces;

namespace ParkCinema.Core.Entities;

public class Film : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int AgeLimit { get; set; }
    public int DurationMinute { get; set; }
    public string? Country { get; set; }
    public string? Director { get; set; }
    public string? Actors { get; set; }
    public string? Description { get; set; }
    public string? Trailer { get; set; }
    public string? Poster { get; set; }
    public bool IsNew { get; set; }
    public DateTime Date { get; set; }
}
