using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TheHealthyAssistant.Services
{
    public class SmsService
    {
        private string _number;
        private string _emailAddress;
        private string _messageText = "Twój kontakt upadł i potrzebuje natychmiastowej pomocy!";
        private GPSService _gps;
        private string _from = "asystentzdrowia@gmail.com";
        private string _fromPass = "asystentzdrowia6969";

        public SmsService(GPSService gPSService)
        {
            _gps = gPSService;
            var user = App.Database.GetUsersAsync().GetAwaiter().GetResult().FirstOrDefault();

            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.Number))
                {
                    _number = user.Number;
                    _emailAddress = user.Email;
                }
                else
                {
                    _number = "123456";
                    _emailAddress = "klaudiachylarecka@gmail.com";
                }
            }
        }

        public async Task SendSms()
        {
            try
            {
                (double?, double?) location = await _gps.GetLocation();
                string lat = location.Item1 != null ? location.Item1.ToString() : "Nieznana";
                string lon = location.Item2 != null ? location.Item2.ToString() : "Nieznana";
                string messageText = $"{_messageText}. Ostatnio znana lokalizacja: Szerokość geograficzna: {lat}, Długość geograficzna: {lon}";
                var message = new SmsMessage(messageText, new[] { _number });
                await Sms.ComposeAsync(message);
                await SendMail(messageText);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        
        public async Task SendMail(string messageText)
        {
            try
            {
                var toAddress = new MailAddress(_emailAddress);
                var fromAddress = new MailAddress(_from);

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_from, _fromPass),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Uwaga!",
                    Body = messageText,
                })
                {
                    await client.SendMailAsync(message).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
