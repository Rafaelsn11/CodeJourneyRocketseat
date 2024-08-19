using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete;

public class DeleteTripByIdUseCase
{
    public void Execute(Guid id)
    {
        var dbcontext = new JourneyDbContext();

        var trip = dbcontext
        .Trips
        .Include(trip => trip.Activities)
        .FirstOrDefault(trip => trip.Id == id);

        if(trip == null)
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);

        dbcontext.Trips.Remove(trip);
        dbcontext.SaveChanges();
    }
}
