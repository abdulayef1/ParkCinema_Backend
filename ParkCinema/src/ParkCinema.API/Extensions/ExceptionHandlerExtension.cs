

using Microsoft.AspNetCore.Diagnostics;
using ParkCinema.API.Middlewares.CustomExceptionMiddleware;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ParkCinema.API.Extensions;

public static class ExceptionHandlerExtension
{
    public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }

}
