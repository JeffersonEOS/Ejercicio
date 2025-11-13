using auriga2.domain.entities;
using auriga2.domain.repositories;
using auriga2.infraestructure.data.contexts;
using auriga2.infraestructure.data.repositories.generics;
namespace auriga2.infraestructure.data.repositories;
public class UserInterestRepository : GenericDataDbRepository<UserInterestEntity>, IUserInterestDomainRepository
{
    public UserInterestRepository(Auriga2Context contex) : base(contex)
    {
        Context = contex;
    }
}