using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Java.Lang;
using Microsoft.AppCenter.Crashes;

namespace MauiAppChapterEightAndNine.ViewModels
{
    public class DataValidationViewModel
    {
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        public ICommand LogInCommand { get; }
        public bool CanLogIn => IsValidEmail(Email) && !string.IsNullOrWhiteSpace(Password);
        public DataValidationViewModel()
        {
            LogInCommand = new Command(async () =>
            {
                //int i = 0;
                //var test = 5 / i;

                var properties = new Dictionary<string, string> {
                        { "Test", "123" },
                        { "Wifi", "On" }
                    };
                Crashes.TrackError(new InvalidDataException(), properties);
                if (CanLogIn)
                {
                    await Shell.Current.DisplayAlert("Log in success", "", "OK");
                }
            });
        }
    }
}
