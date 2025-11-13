using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    EmailTemplateModel CreateEmailTemplate(EmailTemplateModel emailTemplateModel); 
    EmailTemplateModel UpdateEmailTemplate(EmailTemplateModel emailTemplateModel); 
    bool DeleteEmailTemplate(System.Int32 id); 
    PagedCollection<EmailTemplateModel> GetAllEmailTemplateModels(int offset, int limit);
    PagedCollection<EmailTemplateModel> GetEmailTemplateModelsByParam(string param);
}