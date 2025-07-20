using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uas_apk.Models;

namespace uas_apk.Data
{
    public static class NoteRepository
    {
        private static List<Note> _allNotes = new List<Note>();
        private const string NotesFileName = "notes.json";

        public static List<string> Categories { get; set; } = new() { "Hemat Air", "Hemat Listrik", "Transportasi Hijau" };

        public static async Task LoadNotesAsync()
        {
            _allNotes = await DataService.LoadFromJsonAsync<List<Note>>(NotesFileName);
        }

        public static void AddCategory(string category)
        {
            if (!string.IsNullOrWhiteSpace(category) && !Categories.Contains(category))
                Categories.Add(category);
        }

        public static async Task AddNoteForCurrentUser(Note note)
        {
            if (UserRepository.CurrentLoggedInUser == null) return;

            note.UserId = UserRepository.CurrentLoggedInUser.Email;
            _allNotes.Add(note);

            await DataService.SaveToJsonAsync(_allNotes, NotesFileName);
        }

        public static Dictionary<string, int> GetNoteStatsForCurrentUser()
        {
            if (UserRepository.CurrentLoggedInUser == null)
                return new Dictionary<string, int>();

            var currentUserEmail = UserRepository.CurrentLoggedInUser.Email;

            return _allNotes
                .Where(n => n.UserId == currentUserEmail)
                .Where(n => n != null && !string.IsNullOrWhiteSpace(n.Category))
                .GroupBy(n => n.Category)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static List<Note> GetNotesForCurrentUser()
        {
            if (UserRepository.CurrentLoggedInUser == null)
                return new List<Note>(); // Kembalikan list kosong jika tidak ada yang login

            var currentUserEmail = UserRepository.CurrentLoggedInUser.Email;
            return _allNotes.Where(n => n.UserId == currentUserEmail).ToList();
        }
    }
}
