using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.City.Command;

public class CreateCityCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCityCommand, int>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CityRepository.AddAsync(new Domain.Entities.City { Name = request.Name }, cancellationToken);
        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}