## Repositori Tugas Akhir PBO

### Desain

https://www.canva.com/design/DAGY-KM-s-Q/W3tVbCS6WpdxTZ4FwS2UBg/edit?utm_content=DAGY-KM-s-Q&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton

### Kontributor

| Name                       | NIM                |
| -------------------------- | ------------------ |
| Polikarpus Arya Pradhanika | 23/512404/TK/56325 |
| Muhammad Rhizal Rhomadon   | 23/514719/TK/56511 |
| Rafeyfa Asyla              | 23/512856/TK/56361 |

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

- `view <idFilm>`

  Untuk melihat detail film dengan id `<idFilm>`

- ### Memesan tiket film
  Untuk membeli sebuah tiket film, masukan perintah `buy <idFilm>` dengan `<idFilm>` adalah id dari film yang ingin dilihat. `<idFIlm>` dapat dilihat pada beranda.
- ### Melihat seluruh tiket yang telah dipesan
  Untuk melihat seluruh tiket yang telah dipesan, masukan perintah `ticket`
- ### Menambahkan film baru (hanya admin)
- ### Menghapus sebuah film (hanya admin)
