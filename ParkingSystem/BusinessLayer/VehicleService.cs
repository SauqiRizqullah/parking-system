using ParkingSystem.DataAccess;
using ParkingSystem.Model;

namespace ParkingSystem.Business;

public class VehicleService
{

    // private static VehicleRepository _vehicleRepository;
    
    private readonly VehicleRepository _vehicleRepository;

    public VehicleService()
    {
        _vehicleRepository = new VehicleRepository();
    }
    
    public List<List<string>> CreateParkingLot(int jumlahParkir)
    {
        // Buat parkir lot

        var parkingLot = _vehicleRepository.CreateParkingLot(jumlahParkir);
        return parkingLot;
    }

    // public List<List<string>> GetParkingLot(List<List<string>> parkingLot)
    // {
    //     return parkingLot;
    // }
    public void GetParkingLot(List<List<string>> parkingLot)
    {
        // throw new NotImplementedException();
        Console.WriteLine("-------- LAPORAN PARKING LOT --------");
        Console.WriteLine();
        Console.WriteLine("Slot\tNo\t\tType\t\tRegistration No Colour");
        Console.WriteLine();
        
        for (var i = 0; i < parkingLot.Count; i++)
        {
            Console.Write("[");
            for (var j = 0; j < parkingLot[0].Count; j++)
            {
                Console.Write(parkingLot[i][j]);
                if (j != parkingLot[0].Count - 1)
                {
                    Console.Write(",\t ");
                }
            }
            Console.WriteLine("]");
        }
    }

    public void GetVehicleList(List<Vehicle> daftarKendaraan)
    {
        Console.WriteLine();
        Console.WriteLine("-------- DAFTAR KENDARAAN --------");
        Console.WriteLine();
        Console.WriteLine("No\t\tType\tRegistration No Colour");
        Console.WriteLine();
        
        for (var i = 0; i < daftarKendaraan.Count; i++)
        {
            Console.Write("[");
            Console.Write(daftarKendaraan[i].NomorPlat + ",\t ");
            Console.Write(daftarKendaraan[i].TipeKendaraan + ",\t ");
            Console.Write(daftarKendaraan[i].Warna);
            Console.WriteLine("]");
        }
    }

    public Vehicle CreateVehicle(string platNomor, string tipe, string warna)
    {
        return _vehicleRepository.CreateVehicle(platNomor,tipe,warna);
    }

    public List<Vehicle> CreateVehicleList()
    {
        // throw new NotImplementedException();
        return _vehicleRepository.CreateVehicleList();
    }

    public void ParkingVehicle(List<List<string>> parkingLot, List<Vehicle> daftarKendaraan)
    {
        if (daftarKendaraan.Count == 0)
        {
            Console.WriteLine("No vehicles available to park.");
            return;
        }

        Vehicle vehicle = daftarKendaraan[0];
        bool isParked = false;

        for (int i = 0; i < parkingLot.Count; i++)
        {
            if (parkingLot[i][1] == "Available")
            {
                parkingLot[i][1] = vehicle.NomorPlat;
                parkingLot[i][2] = vehicle.TipeKendaraan;
                parkingLot[i][3] = vehicle.Warna;

                Console.WriteLine($"Allocated slot number {i + 1}");
                daftarKendaraan.RemoveAt(0);
                isParked = true;
                break;
            }
        }

        if (!isParked)
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void CheckoutVehicle(List<List<string>> parkingLot, int slotNumber)
    {
        if (slotNumber < 1 || slotNumber > parkingLot.Count)
        {
            Console.WriteLine("Invalid slot number.");
            return;
        }

        if (parkingLot[slotNumber - 1][1] == "Available")
        {
            Console.WriteLine($"Slot number {slotNumber} is already free.");
        }
        else
        {
            parkingLot[slotNumber - 1][1] = "Available";
            parkingLot[slotNumber - 1][2] = "Available";
            parkingLot[slotNumber - 1][3] = "Available";
            Console.WriteLine($"Slot number {slotNumber} is free.");
        }
    }

    public int CountVehiclesByType(List<List<string>> parkingLot, string type)
    {
        int count = 0;
        foreach (var slot in parkingLot)
        {
            if (slot[2] == type)
            {
                count++;
            }
        }
        return count;
    }

    public void SearchByOddSlots(List<List<string>> parkingLot)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < parkingLot.Count; i++)
        {
            if ((i + 1) % 2 != 0 && parkingLot[i][1] != "Available")
            {
                result.Add(parkingLot[i][1]);
            }
        }
        Console.WriteLine("Registration numbers for vehicles parked in odd slots:");
        Console.WriteLine(string.Join(", ", result));
    }

    public void SearchByEvenSlots(List<List<string>> parkingLot)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < parkingLot.Count; i++)
        {
            if ((i + 1) % 2 == 0 && parkingLot[i][1] != "Available")
            {
                result.Add(parkingLot[i][1]);
            }
        }
        Console.WriteLine("Registration numbers for vehicles parked in even slots:");
        Console.WriteLine(string.Join(", ", result));
    }

    public void SearchSlotsByColour(List<List<string>> parkingLot, string colour)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < parkingLot.Count; i++)
        {
            if (parkingLot[i][3] == colour)
            {
                result.Add(i + 1);
            }
        }
        Console.WriteLine($"Slot numbers for vehicles with colour {colour}:");
        Console.WriteLine(string.Join(", ", result));
    }

    public void SearchVehiclesByPlate(List<List<string>> parkingLot, string plate)
    {
        for (int i = 0; i < parkingLot.Count; i++)
        {
            if (parkingLot[i][1] == plate)
            {
                Console.WriteLine($"Slot number for registration number {plate}: {i + 1}");
                return;
            }
        }
        Console.WriteLine($"Registration number {plate} not found.");
    }
}