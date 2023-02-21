using FluentValidation;
using ParkCinema.Business.DTOs.Genre;

namespace ParkCinema.Business.Validators.Genre;

public class GenreCreateDTO_Validator : AbstractValidator<GenreCreateDTO>
{
	public GenreCreateDTO_Validator()
	{
		RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Genre name is requried");

    }
}
