using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using uas_apk.Data;

namespace uas_apk
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Registrasi Gagal", "Silakan isi semua kolom.", "OK");
                return;
            }

            bool registrationSuccess = await UserRepository.RegisterUser(NameEntry.Text, EmailEntry.Text, PasswordEntry.Text);

            if (registrationSuccess)
            {
                await DisplayAlert("Sukses", "Registrasi berhasil! Silakan login.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Registrasi Gagal", "Email ini sudah terdaftar.", "OK");
            }
        }

        private async void OnLoginTapped(object sender, TappedEventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
