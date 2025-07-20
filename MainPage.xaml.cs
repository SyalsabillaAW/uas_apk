using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using uas_apk.Models;
using uas_apk.Data;

namespace uas_apk
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }   

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCategories();
            LoadStats();
        }

        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            UserRepository.LogoutUser();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void LoadCategories()
        {
            categoryPicker.ItemsSource = null;
            categoryPicker.ItemsSource = NoteRepository.Categories;
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descEditor.Text))
            {
                await DisplayAlert("Error", "Deskripsi tidak boleh kosong.", "OK");
                return;
            }

            if (categoryPicker.SelectedIndex == -1 || categoryPicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Kategori harus dipilih.", "OK");
                return;
            }

            string selectedCategory = categoryPicker.SelectedItem?.ToString() ?? string.Empty;

            var newNote = new Note
            {
                Description = descEditor.Text.Trim(),
                Category = selectedCategory,
                Date = DateTime.Now
            };

            await NoteRepository.AddNoteForCurrentUser(newNote);

            descEditor.Text = string.Empty;
            categoryPicker.SelectedIndex = -1;

            await DisplayAlert("Sukses", "Catatan berhasil ditambahkan!", "OK");

            LoadStats();
        }

        private void OnAddCategoryClicked(object sender, EventArgs e)
        {
            string newCat = newCategoryEntry.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(newCat))
            {
                DisplayAlert("Error", "Nama kategori tidak boleh kosong.", "OK");
                return;
            }

            NoteRepository.AddCategory(newCat);
            LoadCategories();

            newCategoryEntry.Text = "";
            DisplayAlert("Sukses", $"Kategori '{newCat}' berhasil ditambahkan.", "OK");
        }

        private void LoadStats()
        {
            var stats = NoteRepository.GetNoteStatsForCurrentUser()
                .Select(kvp => new CategoryStat { CategoryName = kvp.Key, NoteCount = kvp.Value })
                .ToList();

            StatsCollectionView.ItemsSource = stats;
        }
    }
}
