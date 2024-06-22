namespace ParkingSystem.Model;

public class Vehicle
{
    // URUTAN TUGAS
    
    // 1. Buat N Tier Architecture terdiri dari Model, Data Accsess Layer, Business Layer, User Layer
    
    // 2. Buat Model
    
    // 3. Buat method Access Layer per soal (banyak)
    
    // 4. Buat method business Layer per soal (banyak)
    
    // 5. Buat user layer (panggil method dan masukkan nilai)

    public string NomorPlat { get; set; }

    public string TipeKendaraan { get; set; }

    public string Warna { get; set; }

    public Vehicle(string nomorPlat, string tipeKendaraan, string warna)
    {
        NomorPlat = nomorPlat;
        TipeKendaraan = tipeKendaraan;
        Warna = warna;
    }
    
    public Vehicle()
    {
        
    }

    
}
