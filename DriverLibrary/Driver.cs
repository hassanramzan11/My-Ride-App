using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using LocationLibrary;
using VehicleLibrary;

namespace DriverLibrary
{
    public class Driver
    {
        // Attributes
        private string ID;
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phoneNo;
        private Location currLocation;
        private Vehicle vehicle;
        private List<int> rating;
        private bool availability;



        public void StoreDriverData(string fileName)
        {
            string availe = "";
            if (!availability)
            {
                availe = "Not Available";
            }
            else
            {
                availe = "Available";
            }
            // Combine all the necessary data into a string
            string data = $"<->Driver Name : {name}, Driver Age: {age} , Gender : {gender} ,\t\t\nAddress: {address} , Phone Number {phoneNo} , Availability : {availe} , Vehicle Type : {vehicle.VehicleType} , Vehicle Model : {vehicle.VehicleModel} , Vehicle  License Plate : {vehicle.VehicleLicense} ";

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(data);
                File.WriteAllText(fileName, availe );
            }
        }


        // Default Constructor
        public Driver()
        {
            ID = "";
            name = "";
            age = 0;
            gender = "";
            address = "";
            phoneNo = "";
            currLocation = new Location(0, 0);
            vehicle = new Vehicle();
            rating = new List<int>();
            availability = true;
        }

        public Driver(string name, int age, string gender, string address, Vehicle vehicle)
        {
            ID = generateID();
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.address = address;
            this.vehicle = vehicle;
            rating = new List<int>();
            currLocation = new Location(0, 0);
        }
        public Driver(Driver other)
        {
            this.ID = other.ID;
            this.name = other.name;
            this.age = other.age;
            this.gender = other.gender;
            this.address = other.address;
            this.phoneNo = other.phoneNo;
            this.currLocation = new Location(other.currLocation);
            this.vehicle = new Vehicle(other.vehicle);
            this.rating = new List<int>(other.rating);
            this.availability = other.availability;
        }
        private string generateID()
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 3).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string Driver_ID
        {
            get
            {
                return ID;
            }
        }
        public bool IsAvailable()
        {
            return this.availability;
        }
        public Location CurrentLocation()
        {
            return this.currLocation;
        }
        // Methods
        public void UpdateAvailability()
        {
            Console.Write("Are you currently available to take a ride? (y/n): ");
            Console.ForegroundColor=ConsoleColor.Green;
            char input = Convert.ToChar(Console.ReadLine());
            if (input == 'y' || input == 'Y')
            {
                availability = true;
            }
            else if (input == 'n' || input == 'N')
            {
                availability = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Availability status remains unchanged.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Availability Updated");
            Console.ForegroundColor = ConsoleColor.White;
        }

        
        public void setRating(int rideRating)
        {
            
            this.rating.Add(rideRating);
        }
        
        public int GetRating()
        {
            if (rating.Count == 0)
            {
                return 0;
            }
            else
            {
                int sum = 0;
                foreach (int r in rating)
                {
                    sum += r;
                }
                return sum / rating.Count;
            }
        }

        public void UpdateLocation()
        {
            Console.WriteLine("Enter your current location: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Enter Latitude : ");            
            Console.ForegroundColor = ConsoleColor.Green;
            string? latString = Console.ReadLine();
            float Lat = float.Parse(latString);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Enter Longitude : ");
            Console.ForegroundColor = ConsoleColor.Green;
            string? longString = Console.ReadLine();
            float Long = float.Parse(longString);

            if (currLocation == null)
            {
                Location NewLocation=new Location(Lat, Long);
                currLocation = NewLocation;
            }
            Console.WriteLine("Location Updated Successfully");
            Console.ForegroundColor = ConsoleColor.White;
        }

        

        public string Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string Name 
        { 
            get 
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return phoneNo;
            }
            set
            {
                phoneNo = value;
            }
        }
        public bool Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
            }
        }
        public Location Curr
        {
            get
            {
                return currLocation;
            }
            set
            {
                currLocation = value;
            }
        }





    }


}