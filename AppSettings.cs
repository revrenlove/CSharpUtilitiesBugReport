namespace RevrenLove.CSharpUtilitiesBugReport;

public class AppSettings
{
    public required string ToEmailAddress { get; set; }
    public required string FromEmailAddress { get; set; }

    public required string SmtpHost { get; set; }
    public required int SmtpHostPortNumber { get; set; }

    public required string EmailAccountLogin { get; set; }
    public required string EmailAccountKey { get; set; }
}