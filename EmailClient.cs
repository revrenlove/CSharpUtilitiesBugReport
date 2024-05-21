using System.Net;
using System.Net.Mail;

namespace RevrenLove.CSharpUtilitiesBugReport;

public class EmailClient(AppSettings appSettings)
{
    public void SendMessage(string messageBody)
    {
        using var smtpClient = CreateSmtpClient();
        using var message = CreateMailMessage(messageBody);
        smtpClient.Send(message);
    }

    private SmtpClient CreateSmtpClient()
    {
        var smtpClient = new SmtpClient
        {
            Host = appSettings.SmtpHost,
            Port = appSettings.SmtpHostPortNumber,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(appSettings.EmailAccountLogin, appSettings.EmailAccountKey),
        };

        return smtpClient;
    }

    private MailMessage CreateMailMessage(string messageBody)
    {
        var mailMessage = new MailMessage(
            appSettings.FromEmailAddress,
            appSettings.ToEmailAddress,
            "C# Utilities Bug Report",
            messageBody
        );

        return mailMessage;
    }
}
