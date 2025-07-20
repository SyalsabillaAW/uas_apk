GreenNote Application

Catat Kebaikanmu untuk Bumi (Log Your Good Deeds for the Earth)



Aplikasi pencatatan sederhana untuk membantu pengguna melacak dan merekam kegiatan ramah lingkungan yang mereka lakukan sehari-hari. Proyek ini dikembangkan sebagai bagian dari tugas Ujian Akhir Semester (UAS) mata kuliah Aplikasi Piranti Bergerak.



Tim Pengembang:



Syalsabilla Azzahra Wibowo



Tarisa Salsabila



Remmy Ardian



📋 Tentang Proyek

GreenNote adalah aplikasi lintas platform yang dirancang untuk meningkatkan kesadaran lingkungan melalui pencatatan pribadi. Seringkali, tindakan kecil seperti menghemat listrik atau memilah sampah terasa tidak signifikan. GreenNote hadir untuk mengubah persepsi tersebut dengan menyediakan alat bagi pengguna untuk melihat akumulasi dari kebiasaan baik mereka, memberikan rasa pencapaian dan motivasi untuk terus berkontribusi.



Aplikasi ini dibangun menggunakan .NET MAUI, memungkinkan pengembangan untuk Android, iOS, dan Windows dari satu basis kode.



✨ Fitur Utama

Sistem Pengguna Privat: Fitur registrasi dan login yang aman untuk memastikan data setiap pengguna bersifat pribadi.



Pencatatan Kegiatan: Antarmuka yang mudah untuk mencatat kegiatan ramah lingkungan, lengkap dengan pilihan kategori.



Manajemen Kategori: Pengguna dapat menambahkan kategori baru yang sesuai dengan kebutuhan mereka.



Statistik Progres: Tampilan ringkasan jumlah catatan per kategori di halaman utama untuk melacak progres.



Riwayat Harian: Halaman riwayat yang menampilkan semua catatan, dikelompokkan berdasarkan tanggal untuk memudahkan peninjauan.



Penyimpanan Permanen: Data pengguna dan catatan disimpan secara permanen di perangkat menggunakan file JSON, sehingga tidak akan hilang saat aplikasi ditutup.



🚀 Cara Menjalankan Proyek

Untuk menjalankan proyek ini di lingkungan pengembangan lokal Anda, ikuti langkah-langkah berikut.



Prasyarat

Visual Studio 2022 dengan beban kerja .NET Multi-platform App UI development terinstal.



Emulator Android atau perangkat Android fisik dengan mode USB Debugging aktif.



Instalasi \& Menjalankan

Clone repositori ini:



git clone https://\[URL-REPOSITORI-ANDA].git



Buka file Solusi: Buka file uas\_apk.sln dengan Visual Studio 2022.



Restore NuGet Packages: Visual Studio akan secara otomatis mengembalikan semua paket yang diperlukan. Jika tidak, klik kanan pada Solution di Solution Explorer dan pilih "Restore NuGet Packages".



Pilih Target Debug: Di toolbar atas, pilih target Anda (misalnya: "Android Emulators -> Pixel 5" atau nama perangkat fisik Anda).



Jalankan Aplikasi: Tekan tombol Play berwarna hijau atau tekan F5 untuk memulai proses build dan menjalankan aplikasi.



🛠️ Struktur Folder \& Konsep Pemrograman

Proyek ini disusun dengan struktur yang bersih dan menerapkan konsep-konsep pemrograman fundamental.



Struktur Folder Penting

/Data: Berisi kelas-kelas service yang menangani logika bisnis dan akses data, seperti UserRepository, NoteRepository, dan DataService (untuk penyimpanan JSON).



/Models: Berisi kelas-kelas model (POCO - Plain Old CLR Object) yang mendefinisikan struktur data, seperti User.cs, Note.cs, dan CategoryStat.cs.



/LoginPage.xaml, /MainPage.xaml, dll.: File-file yang mendefinisikan antarmuka pengguna (UI) dan logika di baliknya (code-behind).



Konsep yang Diterapkan

Class \& Object: Digunakan untuk memodelkan entitas User dan Note.



Inheritance: Semua halaman (MainPage, LoginPage, dll.) mewarisi fungsionalitas dari kelas dasar ContentPage.



Array \& Dictionary: List<T> digunakan untuk mengelola kumpulan data, dan Dictionary<string, int> digunakan untuk memproses statistik.



Layout dan Komponen UI: Pemanfaatan VerticalStackLayout, Border, CollectionView, dan komponen UI lainnya untuk menciptakan antarmuka yang menarik dan fungsional.

