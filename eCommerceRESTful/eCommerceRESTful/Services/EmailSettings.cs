namespace eCommerceRESTful.Services;

// Like a postmans credentials that will be used to inject into the email service.
public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; }
    public string SmtpPassword { get; set; }
}