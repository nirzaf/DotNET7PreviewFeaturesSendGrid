using SendGrid;
using SendGrid.Helpers.Mail;

var apiKey = Environment.GetEnvironmentVariable("SendGridApiKey");
var fromEmailAddress = Environment.GetEnvironmentVariable("FromEmailAddress");
var fromName = Environment.GetEnvironmentVariable("FromName");
var toEmailAddress = Environment.GetEnvironmentVariable("ToEmailAddress");
var toName = Environment.GetEnvironmentVariable("ToName");

var client = new SendGridClient(apiKey);
var message = new SendGridMessage()
{
    From = new EmailAddress(fromEmailAddress, fromName),
    Subject = "Sending with Twilio SendGrid is Fun",
    PlainTextContent = "and easy to do anywhere, especially with C#"
};
message.AddTo(new EmailAddress(toEmailAddress, toName));
var response = await client.SendEmailAsync(message);

// A success status code means SendGrid received the email request and will process it.
// Errors can still occur when SendGrid tries to send the email. 
// If email is not received, use this URL to debug: https://app.sendgrid.com/email_activity 
Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");