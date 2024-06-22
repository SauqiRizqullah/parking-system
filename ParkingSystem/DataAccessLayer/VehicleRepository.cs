using System.Collections;
using ParkingSystem.Model;

namespace ParkingSystem.DataAccess;

public class VehicleRepository
{
    // BELUM

    public Vehicle Vehicle;

    public List<List<string>> CreateParkingLot(int jumlahParkir)
    {
        
        List<List<string>> parkiran = new List<List<string>>();

        for (var i = 0; i < jumlahParkir; i++)
        {
            parkiran.Add(new List<string>());
            parkiran[i].Add((i+1).ToString());
            for (var j = 1; j < 4; j++)
            {
                parkiran[i].Add("Available");
            }
            
        }
        
        Console.WriteLine($"Created a parking lot with {jumlahParkir} slot(s)");
        
        return parkiran;
    }


    public Vehicle CreateVehicle(string platNomor, string tipe, string warna)
    {
        Vehicle vehicle = new Vehicle(platNomor,tipe,warna);
        return vehicle;


    }

    public List<Vehicle> CreateVehicleList()
    {
        List<Vehicle> daftarKendaraan = new List<Vehicle>();
        return daftarKendaraan;
    }
}