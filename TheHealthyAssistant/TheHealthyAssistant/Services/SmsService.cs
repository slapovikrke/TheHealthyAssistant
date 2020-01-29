using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TheHealthyAssistant.Services
{
    public class SmsService
    {
        private string _number;
        private string _messageText = "Twój kontakt upadł i potrzebuje nastychmiastowej pomocy!";

        public SmsService()
        {
            var user = App.Database.GetUsersAsync().GetAwaiter().GetResult().FirstOrDefault();
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.Number))
                    _number = user.Number;
                else
                    _number = "1234";
            }
        }

        public async Task SendSms()
        {
            try
            {
                var message = new SmsMessage(_messageText, new[] { _number });
                await Sms.ComposeAsync(message);
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
    }
}
