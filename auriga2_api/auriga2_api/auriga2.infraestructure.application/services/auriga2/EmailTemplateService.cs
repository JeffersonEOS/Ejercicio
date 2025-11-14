using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application.models.requests;
using auriga2.infraestructure.application.models.responses;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public EmailTemplateModel CreateEmailTemplate(EmailTemplateModel emailTemplateModel) 
    {
        EmailTemplateEntity emailTemplateEntity = this._mapper.Map<EmailTemplateEntity>(emailTemplateModel);
        this._emailTemplateDomainRepository.AddSync(emailTemplateEntity);
        return this._mapper.Map<EmailTemplateModel>(emailTemplateEntity);
    }
    public EmailTemplateModel UpdateEmailTemplate(EmailTemplateModel emailTemplateModel)
    {
        EmailTemplateEntity emailTemplateEntity = this._emailTemplateDomainRepository.FirstOrDefaultSync(x => x.Id == emailTemplateModel.Id);
        if (null == emailTemplateEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        emailTemplateEntity = this._mapper.Map(emailTemplateModel, emailTemplateEntity);
        this._emailTemplateDomainRepository.UpdateSync(emailTemplateEntity);
        return this._mapper.Map<EmailTemplateModel>(emailTemplateEntity);
    }
    public bool DeleteEmailTemplate(System.Int32 id)
    {
        EmailTemplateEntity emailTemplateEntity = this._emailTemplateDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == emailTemplateEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._emailTemplateDomainRepository.RemoveSync(emailTemplateEntity);
        return true;
    }
    public PagedCollection<EmailTemplateModel> GetAllEmailTemplateModels(int offset, int limit)
    {
        PagedCollection<EmailTemplateEntity> emailTemplateEntityList = new PagedCollection<EmailTemplateEntity>();
        List<string> navigationsProperties = new List<string>();
        emailTemplateEntityList = this._emailTemplateDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<EmailTemplateModel>()
        {
            Limit = emailTemplateEntityList.Limit,
            Offset = emailTemplateEntityList.Offset,
            Size = emailTemplateEntityList.Size,
            Items = this._mapper.Map<EmailTemplateModel[]>(emailTemplateEntityList.Items)
        };
    }
    public async Task<MovimientoResponseDto> ObtenerCuentaAsync(MovimientoRequestDto request)
    {
        var cuenta = await _cuentaDomainRepository.ObtenerCuentaAsync(request.NumeroCuenta);

        if (cuenta == null)
            throw new InvalidOperationException("Cuenta no encontrada");

        var response = new MovimientoResponseDto
        {
            NumeroCuenta = cuenta.NumeroCuenta,
            SaldoActual = cuenta.Saldo
        };

        return response;
    }
    public PagedCollection<EmailTemplateModel> GetEmailTemplateModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<EmailTemplateEntity> emailTemplateEntityList = new PagedCollection<EmailTemplateEntity>();
        List<string> navigationsProperties = new List<string>();
        emailTemplateEntityList = this._emailTemplateDomainRepository.GetPaginWhereSync(x => true && (x.Name.Contains(param) || x.TemplateHtml.Contains(param) || x.UserCreatedAt.Contains(param) || x.UserUpdatedAt.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<EmailTemplateModel>()
        {
            Limit = emailTemplateEntityList.Limit,
            Offset = emailTemplateEntityList.Offset,
            Size = emailTemplateEntityList.Size,
            Items = this._mapper.Map<EmailTemplateModel[]>(emailTemplateEntityList.Items)
        };
    }
}