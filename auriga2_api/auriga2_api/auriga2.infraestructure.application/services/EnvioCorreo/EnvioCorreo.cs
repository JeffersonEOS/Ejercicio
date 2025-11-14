using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.services.EnvioCorreo
{
    public class EnvioCorreo : IEnvioCorreo
    {
        private readonly string _correoRemitente = "alvarezjefferson234@gmail.com";
        private readonly string _nombreRemitente = "EOS-Pasantias";
        private readonly string _appPassword = "sgjf nqae dqoq srof"; 
        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo)
        {
            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress(_nombreRemitente, _correoRemitente));
            mensaje.To.Add(MailboxAddress.Parse(destinatario));
            mensaje.Subject = asunto;
            mensaje.Body = new TextPart("html") { Text = cuerpo };

            using var client = new SmtpClient();

          
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(_correoRemitente, _appPassword);

           
            await client.SendAsync(mensaje);

          
            await client.DisconnectAsync(true);
        }
    }
}
