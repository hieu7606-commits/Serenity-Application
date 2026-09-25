using MyRow = Serene.MovieDB.PersonRow;

namespace Serene.MovieDB;

/// <summary>
/// Deletes one person by id. Someone still listed in a movie's cast is refused by the
/// FK_MovieCast_PersonId foreign key; override <c>ValidateRequest</c> for a friendlier message.
/// </summary>
public interface IPersonDeleteHandler : IDeleteHandlerAsync<MyRow, DeleteRequest, DeleteResponse> { }

public class PersonDeleteHandler(IRequestContext context) :
    DeleteRequestHandlerAsync<MyRow, DeleteRequest, DeleteResponse>(context),
    IPersonDeleteHandler
{
}
