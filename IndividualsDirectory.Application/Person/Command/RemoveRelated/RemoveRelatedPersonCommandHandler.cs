using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Command.RemoveRelated;

public class RemoveRelatedPersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveRelatedPersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(RemoveRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.PersonId, cancellationToken) ?? throw new PersonNotFoundException("Person with following id not found");

        await _unitOfWork.PersonRepository.DeleteRelatedIndividualAsync(request.PersonId, request.RelatedPersonId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}