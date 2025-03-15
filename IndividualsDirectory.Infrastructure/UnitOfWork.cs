using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Infrastructure.Repositories;

namespace IndividualsDirectory.Infrastructure;

public class UnitOfWork(IndividualsDbContext context) : IUnitOfWork
{
    private readonly IndividualsDbContext _context = context;
    private ICityRepository? _cityRepository;
    private IPersonRepository? _personRepository;
    private IPhoneNumberRepository? _phoneNumberRepository;
    private IRelatedIndividualRepository? _relatedIndividualRepository;

    public ICityRepository CityRepository => _cityRepository ??= new CityRepository(_context);

    public IPersonRepository PersonRepository => _personRepository ??= new PersonRepository(_context);

    public IPhoneNumberRepository PhoneNumberRepository => _phoneNumberRepository ??= new PhoneNumberRepository(_context);

    public IRelatedIndividualRepository RelatedIndividualRepository => _relatedIndividualRepository ??= new RelatedIndividualRepository(_context);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}