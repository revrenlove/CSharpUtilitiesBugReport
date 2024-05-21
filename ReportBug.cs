using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace RevrenLove.CSharpUtilitiesBugReport;

public class ReportBug(EmailClient emailClient)
{
    [Function("ReportBug")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        string requestBody;
        using (StreamReader reader = new(req.Body))
        {
            requestBody = await reader.ReadToEndAsync();
        }

        emailClient.SendMessage(requestBody);

        return new OkResult();
    }
}
