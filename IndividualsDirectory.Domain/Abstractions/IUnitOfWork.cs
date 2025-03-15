namespace IndividualsDirectory.Domain.Abstractions;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    IPersonRepository PersonRepository { get; }
    IPhoneNumberRepository PhoneNumberRepository { get; }
    IRelatedIndividualRepository RelatedIndividualRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}