using Microsoft.Maui.Controls;
using System;
using uas_apk.Data; 

namespace uas_apk
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Login Gagal", "Silakan isi email dan password.", "OK");
                return;
            }

            bool loginSuccess = UserRepository.LoginUser(EmailEntry.Text, PasswordEntry.Text);

            if (loginSuccess)
            {
                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);
            }
            else
            {
                await DisplayAlert("Login Gagal", "Email atau password salah.", "OK");
            }
        }

        private async void OnRegisterTapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
