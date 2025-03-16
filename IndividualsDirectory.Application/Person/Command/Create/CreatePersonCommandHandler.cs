using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace IndividualsDirectory.Application.Person.Command.Create;

public class CreatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment) : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Domain.Entities.Person>(request);

        if (request.Image != null)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = $"{Guid.NewGuid()}_{request.Image.FileName}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.Image.CopyToAsync(fileStream);
            }

            person.ImagePath = $"/images/{uniqueFileName}";
        }

        await _unitOfWork.PersonRepository.AddAsync(person, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return person.Id;
    }
}