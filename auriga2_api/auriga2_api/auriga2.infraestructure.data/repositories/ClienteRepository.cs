using auriga2.domain.entities;
using auriga2.domain.repositories;
using auriga2.infraestructure.data.contexts;
using auriga2.infraestructure.data.repositories.generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.data.repositories
{
    public class ClienteRepository : GenericDataDbRepository<ClienteEntity>, IClienteDomainRepository
    {
        public ClienteRepository(Auriga2Context context) : base(context)
        {
            Context = context;
        }
    }

}
