using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TheHealthyAssistant.Services
{
    public class GyroscopeService
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Fastest;
        private bool isStarted = false;
        private float gyroscopeSpeed = 0.0f;
        private SmsService _smsService;
        private DateTime _lastSmsDate;

        public GyroscopeService(SmsService smsService)
        {
            _smsService = smsService;
            _lastSmsDate = new DateTime();
            // Register for reading changes.
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }


        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            try
            {
                var data = e.Reading;
                // Process Angular Velocity X, Y, and Z reported in rad/s
                if (Math.Abs(data.AngularVelocity.X) > 7.0f || Math.Abs(data.AngularVelocity.Z) >= 7.0f)
                {
                    if (Math.Abs((_lastSmsDate - DateTime.Now).TotalMinutes) >= 60)
                    {
                        _smsService.SendSms().GetAwaiter().GetResult();
                        _lastSmsDate = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ToggleGyroscope()
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                {
                    Gyroscope.Stop();
                    isStarted = false;
                    gyroscopeSpeed = 0.0f;
                }
                else
                {
                    Gyroscope.Start(speed);
                    isStarted = true;
                    gyroscopeSpeed = 0.0f;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
