using Microsoft.Maui.Controls;
using System.Linq;
using uas_apk.Data;

namespace uas_apk
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadHistory();
        }

        private void LoadHistory()
        {
            var userNotes = NoteRepository.GetNotesForCurrentUser();

            if (userNotes != null && userNotes.Any())
            {
                var groupedNotes = userNotes
                    .GroupBy(note => note.Date.Date)
                    .OrderByDescending(group => group.Key);

                HistoryCollectionView.ItemsSource = groupedNotes;
            }
            else
            {
                HistoryCollectionView.ItemsSource = null;
            }
        }
    }
}
