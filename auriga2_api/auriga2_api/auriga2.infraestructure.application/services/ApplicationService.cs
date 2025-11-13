using AutoMapper;
using Microsoft.Extensions.Configuration;
using auriga2.domain.repositories;


namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {
        private readonly IMapper _mapper;
        private readonly string _tokenKey;
        private readonly IConfiguration _configuration;
        private readonly IUserRoleDomainRepository _userRoleDomainRepository;
        private readonly ICatalogDomainRepository _catalogDomainRepository;
        private readonly IConfigDomainRepository _configDomainRepository;
        private readonly IEmailTemplateDomainRepository _emailTemplateDomainRepository;
        private readonly IRoleDomainRepository _roleDomainRepository;
        private readonly IUserDomainRepository _userDomainRepository;
        private readonly IProjectDomainRepository _projectDomainRepository;
        private readonly IUserInterestDomainRepository _userInterestDomainRepository;


        public ApplicationService(
            IUserRoleDomainRepository userRoleDomainRepository,
            ICatalogDomainRepository catalogDomainRepository,
            IConfigDomainRepository configDomainRepository,
            IEmailTemplateDomainRepository emailTemplateDomainRepository,
            IRoleDomainRepository roleDomainRepository,
            IUserDomainRepository userDomainRepository,
            IProjectDomainRepository projectDomainRepository,
            IUserInterestDomainRepository userInterestDomainRepository,

            IMapper mapper,
            IConfiguration configuration

            )
        {
            this._configuration = configuration;
            this._mapper = mapper;
            this._tokenKey = this._configuration["Jwt:Key"];
            this._userRoleDomainRepository = userRoleDomainRepository;
            this._catalogDomainRepository = catalogDomainRepository;
            this._configDomainRepository = configDomainRepository;
            this._emailTemplateDomainRepository = emailTemplateDomainRepository;
            this._roleDomainRepository = roleDomainRepository;
            this._userDomainRepository = userDomainRepository;
            this._projectDomainRepository = projectDomainRepository;
            this._userInterestDomainRepository = userInterestDomainRepository;

        }
    }
}