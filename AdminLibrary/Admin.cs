using DriverLibrary;
using LocationLibrary;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using VehicleLibrary;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AdminLibrary
{
    public class Admin
    {
        private List<Driver> Drivers = new List<Driver>();
        
        
        public void Case()
        {
            
            while (true)
            {                
                Console.Clear();
                Console.WriteLine("------------------Admin Menu------------------");
                Console.WriteLine("Enter as Admin");
                
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Update Driver");
                Console.WriteLine("4. Search Driver");
                Console.WriteLine("5. Exit as Admin");

                Console.Write("Press 1 to 5 to select an option : ");

                int expression = Convert.ToInt32(Console.ReadLine());

                switch (expression)
                {
                    case 1:

                        AddDriver();
                        break;

                    case 2:

                        RemoveDriver();
                        break;

                    case 3:
                        UpdateDriver();
                        break;

                    case 4:
                        searchDriver();
                        break;

                    case 5:
                        return;

                    default:
                        // code block
                        break;
                }
                
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nDo you want to do this task again? (y/n) or (Y/N) : ");
                Console.ForegroundColor = ConsoleColor.Green;
                string? input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() != "y")
                {
                    break; // exit inner loop
                }
            }
        }        

        public void AddDriver()
        {
            Console.Write("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? AddDriverName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            String AddDriverAgeString = Console.ReadLine();
            int AddDriverAge = Convert.ToInt32(AddDriverAgeString);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? AddDriverGender = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? AddDriverAddress = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;


            Console.Write("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? AddDriverVehicleType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? AddDriverVehicleModel = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? AddDriverVehiclePlate = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;


            Vehicle AddDriverVehicle = new Vehicle(AddDriverVehicleType, AddDriverVehicleModel, AddDriverVehiclePlate);
            Driver newDriver = new Driver(AddDriverName, AddDriverAge, AddDriverGender, AddDriverAddress, AddDriverVehicle);

            Console.Write($"ID Assigned to this user is ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(newDriver.Driver_ID);
            Console.ForegroundColor = ConsoleColor.White;
            this.InsertToDataBase(newDriver);
            Drivers.Add(newDriver);
            


        }
        public void RemoveDriver()
        {
            /*Console.WriteLine("Enter the ID");
            string? removeDriverID = Console.ReadLine();
*/
            Console.WriteLine("Enter Driver ID: ");
            string? removeDriverID;
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                bool flag = true;
                removeDriverID = Console.ReadLine();
                for (int i = 0; i < removeDriverID.Length; i++)
                {
                    if (!Char.IsDigit(removeDriverID[i]))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Enter the ID again");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Driver ID: ");

            }

            int DBid = int.Parse(removeDriverID);
            this.DeleteFromDataBase(DBid);

            Driver driverToRemove = Drivers.Find(driver => driver.Driver_ID == removeDriverID);
            if (driverToRemove == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drivers found.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Drivers.Remove(driverToRemove);

            Console.WriteLine("Driver removed successfully.");
        }

        public void UpdateDriver()
        {            
            Console.WriteLine("Enter Driver ID: ");
            string? updateDriverID;
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                bool flag = true;
                updateDriverID = Console.ReadLine();
                for (int i = 0; i < updateDriverID.Length; i++)
                {
                    if (!Char.IsDigit(updateDriverID[i]))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Enter the ID again");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Driver ID: ");

            }          
            Driver driverToUpdate = Drivers.Find(driver => driver.Driver_ID == updateDriverID);
            
            if (driverToUpdate == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drivers found.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            
            Console.WriteLine("Enter the fields you want to update (leave blank to skip):");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? updatedName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedName))
            {
                driverToUpdate.Name = updatedName;
            }

            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            string? updatedAge = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedAge))
            {
                driverToUpdate.Age = int.Parse(updatedAge);
            }

            Console.Write("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? updatedGender = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedGender))
            {
                driverToUpdate.Gender = updatedGender;
            }

            Console.Write("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? updatedAddress = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedAddress))
            {
                driverToUpdate.Address = updatedAddress;
            }

            Console.Write("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? updatedVehicleType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedVehicleType))
            {
                driverToUpdate.Vehicle.VehicleType = updatedVehicleType;
            }

            Console.Write("Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? updatedVehicleModel = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedVehicleModel))
            {
                driverToUpdate.Vehicle.VehicleModel = updatedVehicleModel;
            }

            Console.Write("Enter Vehicle License Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? updatedLicenseNumber = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(updatedLicenseNumber))
            {
                driverToUpdate.Vehicle.VehicleLicense = updatedLicenseNumber;
            }
            this.updateDataBase(driverToUpdate, updateDriverID);            
            Console.WriteLine("Driver updated successfully.");

        }

        public void searchDriver()
        {
            Console.WriteLine("Enter search parameters (leave blank to skip):");

            Console.Write("Enter Driver ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchDriverID = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchName = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchAgeString = Console.ReadLine();
            int? searchAge = null;
            if (!string.IsNullOrWhiteSpace(searchAgeString))
            {
                searchAge = int.Parse(searchAgeString);
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchGender = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchAddress = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchVehicleType = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchVehicleModel = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? searchVehicleLicense = Console.ReadLine();

            List<Driver> searchResults = Drivers.FindAll(driver =>
                (string.IsNullOrWhiteSpace(searchDriverID) || driver.Driver_ID.Contains(searchDriverID)) &&
                (string.IsNullOrWhiteSpace(searchName) || driver.Name.Contains(searchName)) &&
                (!searchAge.HasValue || driver.Age == searchAge.Value) &&
                (string.IsNullOrWhiteSpace(searchGender) || driver.Gender.Contains(searchGender)) &&
                (string.IsNullOrWhiteSpace(searchAddress) || driver.Address.Contains(searchAddress)) &&
                (string.IsNullOrWhiteSpace(searchVehicleType) || driver.Vehicle.VehicleType == searchVehicleType) &&
                (string.IsNullOrWhiteSpace(searchVehicleModel) || driver.Vehicle.VehicleModel == searchVehicleModel) &&
                (string.IsNullOrWhiteSpace(searchVehicleLicense) || driver.Vehicle.VehicleLicense == searchVehicleLicense)
            );

            if (searchResults.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drivers found.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Search results:");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("ID\tName\t\tAge\tGender\tV.Type\tV.Model\tV.License");
            Console.WriteLine("----------------------------------------------------------------------");
            

            foreach (Driver driver in searchResults)
            {

                Console.WriteLine($"{driver.Driver_ID}\t{driver.Name}\t\t{driver.Age}\t{driver.Gender}\t{driver.Vehicle.VehicleType}\t{driver.Vehicle.VehicleModel}\t{driver.Vehicle.VehicleLicense}");
            }
            Console.ForegroundColor = ConsoleColor.White;      
        }

        public Driver? findDriver(string driverID,string DriverName)
        {
            foreach (Driver driver in Drivers)
            {
                if (driver.Driver_ID == driverID && driver.Name==DriverName)
                {
                    return driver;
                }
            }
            return null; // driver with given ID not found
        }
        public List<Driver> DriversList
        {
            get { return Drivers; }
        }
        
        public List<Driver> AvailableDrivers()
        {
            List<Driver> AvailaibleDriverslist = new List<Driver>();
            foreach (Driver driver in Drivers)
            {
                if (driver.IsAvailable())
                {
                    AvailaibleDriverslist.Add(driver);
                }
            }
            return AvailaibleDriverslist;
        }

        /*public void ReadDrivers()
        {           
            string filePath = @"E:\6 Semester\Web Engineering\HomeWork\BCSF20M049_H02\My Ride App\Drivers.txt";
            this.AddDriverFromFile(filePath, Drivers);
        }

        public void AddDriverFromFile(string filePath, List<Driver> driverList)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }
                var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var fields = line.Split(',');
                var newDriver = new Driver
                {
                    Id = fields[0].Split(':')[1].Trim(),
                    Name = fields[1].Split(':')[1].Trim(),
                    Age = int.Parse(fields[2].Split(':')[1].Trim()),
                    Gender = fields[3].Split(':')[1].Trim(),
                    Address = fields[4].Split(':')[1].Trim(),
                    Availability = bool.Parse(fields[5].Split(':')[1].Trim()),
                    Vehicle = new Vehicle
                    {
                        VehicleType = fields[6].Split(':')[1].Trim(),
                        VehicleModel = fields[7].Split(':')[1].Trim(),
                        VehicleLicense = fields[8].Split(':')[1].Trim()
                    }
                };
                driverList.Add(newDriver);
            }
        }
        public void WriteDriversToFile()
        {
            string fileName = @"E:\6 Semester\Web Engineering\HomeWork\BCSF20M049_H02\My Ride App\Drivers.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Driver driver in Drivers)
                {                    
                    string data = $"ID: {driver.Id},Name: {driver.Name},Age: {driver.Age},Gender: {driver.Gender},Address: {driver.Address},Availaibilty: {driver.Availability},VehicleType: {driver.Vehicle.VehicleType},VehicleModel: {driver.Vehicle.VehicleModel},VehicleLicense: {driver.Vehicle.VehicleLicense}";                 
                    writer.WriteLine(data);
                }
            }
        }*/

        public void InsertToDataBase(Driver driver)
        {
            int rowsAffected = 0;
            string ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MyRideApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = $"Insert into DRIVER (Id, Name, Age, Gender, Address, Availaibility, Vehicle_Type, Vehicle_Model, Vehicle_License) values('{driver.Id}','{driver.Name}','{driver.Age}','{driver.Gender}','{driver.Address}','{driver.Availability}','{driver.Vehicle.VehicleType}','{driver.Vehicle.VehicleModel}','{driver.Vehicle.VehicleLicense}')";
            SqlCommand cmd = new SqlCommand(query, con);
            rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            
            if (rowsAffected > 0)
            {
                Console.WriteLine("\nRows Inserted in DATABASE");
            }
            else
            {
                Console.WriteLine("\nFailed");
            }
        }
        public void DeleteFromDataBase(int id)
        {
            int rowsAffected = 0;
            string ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MyRideApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = $"DELETE FROM DRIVER WHERE Id={id} ";
            SqlCommand cmd = new SqlCommand(query, con);
            rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Rows Deleted from DATABASE");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            
        }


        public void readFromDataBases()
        {            
            string ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MyRideApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string select = $"SELECT * from DRIVER";
            SqlCommand cmd = new SqlCommand(select, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Driver driver = new Driver();
                driver.Id = reader.GetInt32(0).ToString();
                driver.Name = reader.GetString(1);
                driver.Age = reader.GetInt32(2);
                driver.Gender= ((string)reader["Gender"]);
                driver.Availability = bool.Parse(reader["Availaibility"].ToString());
              /*  float lat = float.Parse(reader["Latitude"].ToString());
                float lon = float.Parse(reader["Longitude"].ToString());*/
                string vehicleType = reader.GetString(8);
                string vehicleModel = reader.GetString(9);
                string vehicleLicense = reader.GetString(10);
                /*driver.Curr.lat = ((float)reader["Latitude"]);
                driver.Curr.lng = float.Parse(reader["Longitude"].ToString());*/
                driver.Vehicle.VehicleType = vehicleType;
                driver.Vehicle.VehicleModel = vehicleModel;
                driver.Vehicle.VehicleLicense = vehicleLicense;

                Drivers.Add(driver);
            }
            con.Close();               
        }


        public void updateDataBase(Driver driver,string id)
        {
            string ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MyRideApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = $"Update Driver set Name='{driver.Name}', Age='{driver.Age}', Gender='{driver.Gender}', Address='{driver.Address}', Latitude='{driver.Curr.lat}', Longitude='{driver.Curr.lng}',Availaibility='{driver.Availability}',Vehicle_Type='{driver.Vehicle.VehicleType}', Vehicle_Model='{driver.Vehicle.VehicleModel}', Vehicle_License='{driver.Vehicle.VehicleLicense}' where Id='{id}'";
            con.Open();
            SqlCommand comm = new SqlCommand(query, con);
            int rowsUpdated = comm.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("\nDriver Updated Successfully in DATABASE\n");
        }


    }
}
