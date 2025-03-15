using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Command.AddRelated;

public class AddRelatedPersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddRelatedPersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(AddRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.PersonId, cancellationToken) ?? throw new PersonNotFoundException("Person with following id not found");

        await _unitOfWork.PersonRepository.AddRelatedIndividualAsync(request.PersonId, request.RelatedPersonId, request.Relationship);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}