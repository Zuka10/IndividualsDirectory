using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Command.Delete;

public class DeletePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.Id, cancellationToken) ?? throw new PersonNotFoundException("person with following id not found");

        _unitOfWork.PersonRepository.Remove(person);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}