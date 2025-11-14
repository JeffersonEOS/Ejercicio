using System.Threading.Tasks;

namespace auriga2.infraestructure.application.services.EnvioCorreo
{
    public interface IEnvioCorreo
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo);
    }
}
