using auriga2.domain.repositories;
using auriga2.infraestructure.application.services.EnvioCorreo;
using AutoMapper;
using Microsoft.Extensions.Configuration;


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
        private readonly IBancoDomainRepository   _bancoDomainRepository;
        private readonly IClienteDomainRepository  _clienteDomainRepository;
        private readonly ICuentaDomainRepository _cuentaDomainRepository;
        private readonly ISucursalDomainRepository _sucursalDomainRepository;
        private readonly ITransaccionDomainRepository _transaccionDomainRepository;
        private readonly IEnvioCorreo _envioCorreo;

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
            IConfiguration configuration,
            ITransaccionDomainRepository transaccionDomainRepository,
            ISucursalDomainRepository sucursalDomainRepository,
            ICuentaDomainRepository cuentaDomainRepository,
            IClienteDomainRepository clienteDomainRepository,
            IBancoDomainRepository bancoDomainRepository,
            IEnvioCorreo envioCorreo
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



            this._bancoDomainRepository = bancoDomainRepository;
            this._cuentaDomainRepository = cuentaDomainRepository;
            this._clienteDomainRepository = clienteDomainRepository;
            this._sucursalDomainRepository = sucursalDomainRepository;
            this._transaccionDomainRepository = transaccionDomainRepository;
            this._envioCorreo = envioCorreo;





        }
    }
}