## Repositori Tugas Akhir PBO

### Desain

https://www.canva.com/design/DAGY-KM-s-Q/W3tVbCS6WpdxTZ4FwS2UBg/edit?utm_content=DAGY-KM-s-Q&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton

### Kontributor

| Name                       | NIM                |
| -------------------------- | ------------------ |
| Polikarpus Arya Pradhanika | 23/512404/TK/56325 |
| Muhammad Rhizal Rhomadon   | 23/514719/TK/56511 |
| Rafeyfa Asyla              | 23/512856/TK/56361 |

### Struktur Kode

```
app/
  db/
  model/
  pages/
  utils/
  Program.cs
  TerminalDisplay.cs
```

- `db/` berupa folder berisi seluruh database yang ada pada aplikasi
- `model/` berupa folder berisi model dari database. Terdapat dua model yang digunakan yakni model `Users` dan `Films`
- `pages/` berupa folder berisi implementasi dari setiap halaman yang ada pada aplikasi
- `utils/` berupa folder berisi fungsi - fungsi pembantu yang memudahkan proses pengembangan aplikasi
- `Program.cs` merupakan kode utama yang dijalankan oleh program
- `TerminalDisplay.cs` merupakan kode yang mengatur halaman apa saja yang akan ditampilkan oleh program saat ini

### Kebutuhan

- NET 0.9 Framework

### How to Run

1. Pertama, clone terlebih dahulu repositori

   - Dengan HTTPS

     ```
     git clone https://github.com/mie-intel/pbo-ta-bioskop.git
     ```

   - Dengan SSH

     ```
     git clone git@github.com:mie-intel/pbo-ta-bioskop.git
     ```

2. Pergi ke folder app dengan perintah
   ```
    cd app/
   ```
3. Jalankan aplikasi dengan perintah
   ```
   dotnet run
   ```

### Akun Pengguna

1. Saat pertama kali dijalankan, anda akan diminta untuk login / mendaftarkan terlebih dahulu akun anda. Silakan pilih yang paling sesuai
2. Akun yang sudah tersedia pada aplikasi adalah sebagai berikut

| username | password | Akses Admin? |
| -------- | -------- | ------------ |
| Admin    | admin123 | Ya           |
| poli     | arya     | Tidak        |
| Rhizal   | dfahb    | Tidak        |

3. Akun admin digunakan apabila ingin menambahkan film baru / menghapus film yang sudah ada.
4. Akun biasa digunakan apabila ingin berinteraksi dengan aplikasi seperti biasa
5. Setelah login, anda akan masuk ke tampilan utama pada aplikasi. Anda akan dapat melihat seluruh film yang tersedia di dalam aplikasi

### Perintah yang tersedia

- #### ADDFILM (hanya admin)

  ```
  addfilm
  ```

  Untuk menambahkan film baru

- #### BUY

  ```
  buy [idFilm]
  ```

  Untuk membeli film dengan id `[idFilm]`

- #### DELFILM (hanya admin)

  ```
  delfilm [idFilm]
  ```

  Untuk menghapus film dengan id `[idFilm]`

- #### HELP

  ```
  help
  ```

  Untuk mendapatakan bantuan terkait perintah yang tersedia

- #### TICKET

  ```
  ticket
  ```

  Untuk melihat seluruh tiket yang telah dipesan

- #### TOPUP

  ```
  topup [uang]
  ```

  Untuk menambahkan uang ke dalam akun sebanyak `[uang]` rupiah. `[uang]` harus berupa bilangan bulat tanpa titik ataupun koma pemisah.

- #### VIEW

  ```
  view [idFilm]
  ```

  Untuk melihat detail film dengan id `[idFilm]`
