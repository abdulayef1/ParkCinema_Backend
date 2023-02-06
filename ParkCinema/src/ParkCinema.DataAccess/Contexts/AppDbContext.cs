using Microsoft.EntityFrameworkCore;

namespace ParkCinema.DataAccess.Contexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)	
	{

	}
}
