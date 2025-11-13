using auriga2.domain.entities;
using auriga2.domain.repositories;
using auriga2.infraestructure.data.contexts;
using auriga2.infraestructure.data.repositories.generics;
namespace auriga2.infraestructure.data.repositories;
public class UserRepository : GenericDataDbRepository<UserEntity>, IUserDomainRepository
{
    public UserRepository(Auriga2Context contex) : base(contex)
    {
        Context = contex;
    }
}