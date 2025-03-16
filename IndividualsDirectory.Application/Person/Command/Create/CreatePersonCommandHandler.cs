﻿using AutoMapper;
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
        var phoneNumbers = _mapper.Map<List<Domain.Entities.PhoneNumber>>(request.PhoneNumbers);
        var relatedIndividuals = _mapper.Map<List<Domain.Entities.RelatedIndividual>>(request.RelatedIndividuals);

        person.PhoneNumbers = phoneNumbers;
        person.RelatedIndividuals = relatedIndividuals;

        await _unitOfWork.PersonRepository.AddAsync(person, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return person.Id;
    }
}