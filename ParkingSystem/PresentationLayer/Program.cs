// See https://aka.ms/new-console-template for more information


using ParkingSystem.Business;
using ParkingSystem.Model;

public class Program
{

    // private static VehicleService _vehicleService;
    
    public static void Main(string[] args)
    {
        
        Start();
    }

    public static void Start()
    {
        Console.WriteLine("----- PARKING SYSTEM -----");
        
        Console.WriteLine();
        
        VehicleService _vehicleService = new VehicleService();

        // panggil service CreatingParkingLot
        Console.Write("Tentukan jumlah slot parkir: ");
        int slotNumber = Convert.ToInt32(Console.ReadLine());
        var parkingLot = _vehicleService.CreateParkingLot(slotNumber);
        Console.WriteLine();
        var daftarKendaraan = _vehicleService.CreateVehicleList();
        View(_vehicleService, parkingLot,daftarKendaraan);
        
    }

    public static void View(VehicleService vehicleService, List<List<string>> parkingLot, List<Vehicle> daftarKendaraan)
    {
        Console.WriteLine("----- PARKING SYSTEM -----");
        Console.WriteLine();
        Console.WriteLine("Silahkan memilih fitur:");
        Console.WriteLine("1. Parking vehicle"); // output console log. logic parkir tambahkan logic ketika full
        Console.WriteLine("2. Checkout park"); // output console log
        Console.WriteLine("3. Counting by type of vehicle"); // output int logic motor dan mobil
        Console.WriteLine("4. Searching by park's odd number"); // output console log
        Console.WriteLine("5. Searching by park's even number"); // output console log
        Console.WriteLine("6. Searching park's number by vehicle colour"); // output console log
        Console.WriteLine("7. Searching vehicle by number plate"); // output consol log
        Console.WriteLine("8. Creating Vehicle Object"); 
        Console.WriteLine("9. Get Report of Parking Lot");
        Console.Write("Nomor pilihan anda:");
        
        int nomorFitur = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        switch (nomorFitur)
        {
            case 1:
                if (daftarKendaraan.Count > 0)
                {
                    vehicleService.ParkingVehicle(parkingLot, daftarKendaraan);
                }
                else
                {
                    Console.WriteLine("No vehicles available to park. Please create a vehicle first.");
                }
                break;
            case 2:
                Console.Write("Masukkan nomor slot yang ingin keluar: ");
                int slotNumber = Convert.ToInt32(Console.ReadLine());
                vehicleService.CheckoutVehicle(parkingLot, slotNumber);
                break;
            case 3:
                Console.Write("Masukkan tipe kendaraan (Motor/Mobil): ");
                string type = Console.ReadLine();
                int count = vehicleService.CountVehiclesByType(parkingLot, type);
                Console.WriteLine($"Jumlah kendaraan dengan tipe {type}: {count}");
                break;
            case 4:
                vehicleService.SearchByOddSlots(parkingLot);
                break;
            case 5:
                vehicleService.SearchByEvenSlots(parkingLot);
                break;
            case 6:
                Console.Write("Masukkan warna kendaraan: ");
                string colour = Console.ReadLine();
                vehicleService.SearchSlotsByColour(parkingLot, colour);
                break;
            case 7:
                Console.Write("Masukkan nomor plat kendaraan: ");
                string plate = Console.ReadLine();
                vehicleService.SearchVehiclesByPlate(parkingLot, plate);
                break;
            case 8:
                Console.Write("Silahkan input nomor plat kendaraan: ");
                string nomorPlat = Console.ReadLine();
                Console.Write("Silahkan input tipe kendaraan: ");
                string tipe = Console.ReadLine();
                Console.Write("Silahkan input warna kendaraan: ");
                string warna = Console.ReadLine();
                daftarKendaraan.Add(vehicleService.CreateVehicle(nomorPlat, tipe, warna));
                vehicleService.GetVehicleList(daftarKendaraan);
                break;
            case 9:
                vehicleService.GetParkingLot(parkingLot);
                break;
            default:
                Console.WriteLine("Pilihan tidak valid.");
                break;
        }
        
        Console.WriteLine();
        View(vehicleService, parkingLot, daftarKendaraan);
    }

    public static void Report()
    {
        
    }
    
}