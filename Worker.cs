using System.Net.Mail;

namespace NotificacionesPorCorreoServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public void Email(string destinatario, string asunto, string cuerpo)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(destinatario, ""));
            mail.From = new MailAddress("DESDE");
            mail.Subject = asunto;
            mail.Body = cuerpo;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("DESDE", "PASS");
            smtp.Send(mail);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DateTime fechaProgramada = new DateTime(2023, 6, 7, 23, 31, 0);
            await Task.Delay(fechaProgramada - DateTime.Now, stoppingToken);
            Email("PARA", "SUBJECT", "BODY");
        }
    }
}