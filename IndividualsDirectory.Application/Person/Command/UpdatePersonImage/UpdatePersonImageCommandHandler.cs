using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Command.UpdatePersonImage;

public class UpdatePersonImageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePersonImageCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(UpdatePersonImageCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.Id, cancellationToken) ?? throw new PersonNotFoundException("person with following id not found");

        person.ImagePath = request.ImagePath;
        await _unitOfWork.PersonRepository.UpdateAsync(person, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}