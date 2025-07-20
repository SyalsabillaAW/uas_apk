using System;

namespace uas_apk.Models
{
    public class Note
    {
        // Properti baru untuk menyimpan email pengguna sebagai ID unik
        public string UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
