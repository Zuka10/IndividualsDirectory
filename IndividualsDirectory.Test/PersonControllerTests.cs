using FluentAssertions;
using IndividualsDirectory.Api.Controllers;
using IndividualsDirectory.Application.Person;
using IndividualsDirectory.Application.Person.Command.AddRelated;
using IndividualsDirectory.Application.Person.Command.Create;
using IndividualsDirectory.Application.Person.Command.Delete;
using IndividualsDirectory.Application.Person.Command.RemoveRelated;
using IndividualsDirectory.Application.Person.Command.Update;
using IndividualsDirectory.Application.Person.Query.GetAll;
using IndividualsDirectory.Application.Person.Query.GetById;
using IndividualsDirectory.Application.Person.Query.RelatedReport;
using IndividualsDirectory.Application.Person.Query.Search;
using IndividualsDirectory.Domain.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace IndividualsDirectory.Test;

public class PersonControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly PersonController _controller;

    public PersonControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new PersonController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetIndividualsReport_ShouldReturnOkWithReport()
    {
        var report = new List<RelatedIndividualsReportModel>
            {
                new() { PersonId = 1, RelationshipType = Domain.Enums.RelationshipType.Relative, RelatedIndividualsCount = 2 }
            };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetRelatedIndividualsReportQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(report);

        var result = await _controller.GetIndividualsReport();

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(report);
    }

    [Fact]
    public async Task Search_ShouldReturnOkWithResults()
    {
        var searchResults = new List<PersonDto> { new() { Id = 1, FirstName = "John", LastName = "Doe" } };

        _mediatorMock.Setup(m => m.Send(It.IsAny<SearchPersonQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(searchResults);

        var result = await _controller.Search("John");

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(searchResults);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOkWithResults()
    {
        var persons = new List<PersonDto> { new() { Id = 1, FirstName = "Alice", LastName = "Smith" } };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPersonQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(persons);

        var result = await _controller.GetAll();

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(persons);
    }

    [Fact]
    public async Task Get_ShouldReturnOkWithPerson()
    {
        var person = new PersonDto { Id = 1, FirstName = "Bob", LastName = "Brown" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetPersonByIdQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(person);

        var result = await _controller.Get(1);

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(person);
    }

    [Fact]
    public async Task Create_ShouldReturnOk()
    {
        var command = new CreatePersonCommand
        {
            FirstName = "Jane",
            LastName = "Doe",
            BirthDate = new DateTime(1998, 01, 10, 0, 0, 0, DateTimeKind.Local),
            Gender = Domain.Enums.GenderType.Female,
            PersonalNumber = "12345678911"
        };

        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                 .ReturnsAsync(1);

        var result = await _controller.Create(command);

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be("Created successfully");
    }

    [Fact]
    public async Task AddRelated_ShouldReturnOk()
    {
        var command = new AddRelatedPersonCommand { PersonId = 1, RelatedPersonId = 2, Relationship = Domain.Enums.RelationshipType.Relative };

        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                     .ReturnsAsync(true);

        var result = await _controller.AddRelated(command);

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be("Added successfully");
    }

    [Fact]
    public async Task RemoveRelated_ShouldReturnOk()
    {
        var command = new RemoveRelatedPersonCommand { PersonId = 1, RelatedPersonId = 2 };

        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                     .ReturnsAsync(true);

        var result = await _controller.RemoveRelated(command);

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be("Removed successfully");
    }

    [Fact]
    public async Task Update_ShouldReturnOk()
    {
        var command = new UpdatePersonCommand { Id = 1, FirstName = "Updated", LastName = "Name" };

        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                     .ReturnsAsync(true);

        var result = await _controller.Update(command);

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be("Updated successfully");
    }

    [Fact]
    public async Task Delete_ShouldReturnOk()
    {
        var command = new DeletePersonCommand { Id = 1 };

        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                     .ReturnsAsync(true);

        var result = await _controller.Delete(1);

        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().Be("Deleted successfuly");
    }
}